using System.Collections.Generic;

namespace U8.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 关键字匹配管理器
    /// </summary>
    public class U8KeywordMatchManager
    {
        private U8AbstractMatchNode rootNode = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="keywords">关键字列表</param>
        public U8KeywordMatchManager(IEnumerable<string> keywords)
        {
            rootNode = new U8CompressionMatchNode(char.MinValue);
            this.MatchKeywords(keywords);
            this.MatchFailoverNode();
        }

        /// <summary>
        /// 查找关键字
        /// </summary>
        /// <param name="keywords">关键字列表</param>
        private void MatchKeywords(IEnumerable<string> keywords)
        {
            foreach (var item in keywords)
            {
                var currentNode = rootNode;

                foreach (var c in item.ToCharArray())
                {
                    currentNode = currentNode.AddChar(c);
                }
                currentNode.SetKeyword(item);
                currentNode.ResetPosition();
            }
        }

        private void MatchFailoverNode()
        {
            Queue<U8FailOverNode> queue = new Queue<U8FailOverNode>();

            foreach (var item in rootNode.Children)
            {
                var node = item;
                node.CurrentFailover = new U8FailOverNode { Offset = 0, Node = rootNode };
                if (node.MoveToNextPosition())
                {
                    queue.Enqueue(new U8FailOverNode { Offset = node.CurrentPosition, Node = item });
                }
                else
                {
                    foreach (var subItem in item.Children)
                    {
                        queue.Enqueue(new U8FailOverNode { Offset = 0, Node = subItem });
                    }
                }
            }

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                var node = item.Node;
                node.SetPosition(item.Offset);
                node.MatchFailOver(rootNode);
                if (item.Offset < (node.Content.Length - 1))
                {
                    item.Offset++;
                    queue.Enqueue(item);
                }
                else
                {
                    foreach (var subItem in item.Node.Children)
                    {
                        queue.Enqueue(new U8FailOverNode { Offset = 0, Node = subItem });
                    }
                }
            }
            (rootNode as U8IMatchNode).CurrentFailover = new U8FailOverNode { Node = rootNode, Offset = 0 };
        }

        private U8AbstractMatchNode GetFailoverNode(U8AbstractMatchNode node, char c)
        {
            U8AbstractMatchNode currentNode = node.CurrentFailover.Node;
            currentNode.SetPosition(node.CurrentFailover.Offset);
            if (currentNode != rootNode)
            {
                if (currentNode.HasChild(c))
                {
                    var temp = currentNode.GetChild(c);
                    currentNode.ResetPosition();
                    currentNode = temp;
                }
                else
                {
                    var temp = this.GetFailoverNode(currentNode, c);
                    currentNode.ResetPosition();
                    currentNode = temp;
                }
            }
            return currentNode;
        }

        private void GetMatchedResultOnFailoverNode(List<U8MatchResult> matchResults, char c, int index, U8AbstractMatchNode node)
        {
            U8AbstractMatchNode currentNode = node.CurrentFailover.Node;
            currentNode.SetPosition(node.CurrentFailover.Offset);
            while (currentNode != rootNode)
            {
                if (!string.IsNullOrEmpty(currentNode.CurrentKeyword))
                {
                    matchResults.Add(new U8MatchResult { Length = currentNode.CurrentKeyword.Length, StartIndex = index - currentNode.CurrentKeyword.Length, Keyword = currentNode.CurrentKeyword });
                }
                var temp = currentNode.CurrentFailover.Node;
                temp.SetPosition(currentNode.CurrentFailover.Offset);
                currentNode.ResetPosition();
                currentNode = temp;
            }
            currentNode.ResetPosition();
        }

        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>结果</returns>
        public IEnumerable<U8MatchResult> Match(string content)
        {
            List<U8MatchResult> matchResults = new List<U8MatchResult>();
            U8AbstractMatchNode currentNode = rootNode;
            int index = 0;
            foreach (var c in content.ToCharArray())
            {
                if (currentNode.HasChild(c))
                {
                    currentNode = currentNode.GetChild(c);
                }
                else
                {
                    if (currentNode != rootNode)
                    {
                        currentNode = this.GetFailoverNode(currentNode, c);
                    }
                }
                if (!string.IsNullOrEmpty(currentNode.CurrentKeyword))
                {
                    matchResults.Add(new U8MatchResult { Length = currentNode.CurrentKeyword.Length, StartIndex = index - currentNode.CurrentKeyword.Length, Keyword = currentNode.CurrentKeyword });
                }
                if (currentNode != rootNode)
                {
                    GetMatchedResultOnFailoverNode(matchResults, c, index, currentNode);
                }
                index++;
            }
            return matchResults;
        }
    }
}