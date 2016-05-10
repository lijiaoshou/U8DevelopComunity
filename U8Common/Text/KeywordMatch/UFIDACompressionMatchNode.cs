using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 压缩匹配节点
    /// </summary>
    public class UFIDACompressionMatchNode : UFIDAAbstractMatchNode
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="c">字符</param>
        public UFIDACompressionMatchNode(char c)
            : base()
        {
            Content = c.ToString();
            matchKeywords.Add(string.Empty);
            failovers.Add(null);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="matchedKeywords">匹配关键字</param>
        /// <param name="failoverNodes">失效点</param>
        public UFIDACompressionMatchNode(string content, IEnumerable<string> matchedKeywords, IEnumerable<UFIDAFailOverNode> failoverNodes)
        {
            Content = content;
            matchKeywords.AddRange(matchedKeywords);
            failovers.AddRange(failoverNodes);
        }


        private void AddChild(UFIDAAbstractMatchNode node)
        {
            node.Parent = this;
            children.Add(node);
        }

        /// <summary>
        /// 增加字符
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        public override UFIDAAbstractMatchNode AddChar(char c)
        {
            var currentNode = this;
            if (CurrentChar == char.MinValue)
            {
                if (this.children.Any(e => e.CurrentChar == c))
                {
                    currentNode = this.children.First(e => e.CurrentChar == c) as UFIDACompressionMatchNode;
                }
                else
                {
                    var childNode = new UFIDACompressionMatchNode(c);
                    this.AddChild(childNode);
                    currentNode = childNode;
                    currentNode.MoveToNextPosition();
                }
            }
            else
            {
                if (this.MoveToNextPosition())
                {
                    if (CurrentChar != c)
                    {
                        int iIndex = this.currentPosition;
                        int iCount = this.Content.Length - iIndex;
                        var newNodeFirst = new UFIDACompressionMatchNode(c);
                        var newNodeSecond = new UFIDACompressionMatchNode(this.Content.Substring(iIndex), matchKeywords.GetRange(iIndex, iCount), failovers.GetRange(iIndex, iCount));
                        this.matchKeywords.RemoveRange(iIndex, iCount);
                        this.failovers.RemoveRange(iIndex, iCount);
                        this.Content = this.Content.Substring(0, iIndex);
                        foreach (var item in this.children)
                        {
                            newNodeSecond.AddChild(item);
                        }
                        this.children.Clear();
                        this.AddChild(newNodeFirst);
                        this.AddChild(newNodeSecond);
                        currentNode = newNodeFirst;
                        this.ResetPosition();
                    }
                }
                else
                {
                    if (this.Children.Count() == 0)
                    {
                        this.Content = string.Concat(this.Content, c);
                        matchKeywords.Add(string.Empty);
                        failovers.Add(null);
                        this.MoveToNextPosition();
                    }
                    else
                    {
                        if (this.children.Any(e => e.CurrentChar == c))
                        {
                            currentNode = this.children.First(e => e.CurrentChar == c) as UFIDACompressionMatchNode;
                        }
                        else
                        {
                            var childNode = new UFIDACompressionMatchNode(c);
                            this.AddChild(childNode);
                            currentNode = childNode;
                            currentNode.MoveToNextPosition();
                        }
                    }
                }
            }
            if (currentNode != this)
            {
                this.ResetPosition();
            }
            return currentNode;
        }

        /// <summary>
        /// 重构ToString
        /// </summary>
        /// <returns>结果</returns>
        public override string ToString()
        {
            return this.Content;
        }

        /// <summary>
        /// 找到失效点
        /// </summary>
        /// <param name="root">根</param>
        public override void MatchFailOver(UFIDAAbstractMatchNode root)
        {
            char c = this.CurrentChar;
            int offset = this.currentPosition;
            var failover = this.ParentFailover;
            var temp = failover;
            while (temp != null)
            {
                var node = temp.Node;
                node.SetPosition(temp.Offset);
                if (node.HasChild(c))
                {
                    break;
                }
                temp = node.ParentFailover;
                node.ResetPosition();
            }
            if (temp == null)
            {
                this.CurrentFailover = new UFIDAFailOverNode { Node = root, Offset = 0 };
            }
            else
            {
                var node = temp.Node;
                node.SetPosition(temp.Offset);
                var nnode = node.GetChild(c);
                this.SetFailover(offset, new UFIDAFailOverNode { Node = nnode, Offset = nnode.CurrentPosition });
                node.ResetPosition();
            }
        }

        /// <summary>
        /// 父级失效点
        /// </summary>
        public override UFIDAFailOverNode ParentFailover
        {
            get
            {
                UFIDAFailOverNode node = null;
                if (currentPosition > 0)
                {
                    node = this.failovers[currentPosition - 1];
                }
                else if (null != this.Parent)
                {
                    node = this.Parent.Failovers.Last();
                }
                return node;
            }
        }

        /// <summary>
        /// 判断是否有子节点
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        public override bool HasChild(char c)
        {
            bool result = false;
            if (currentPosition < (this.Content.Length - 1))
            {
                char cNewChar = this.Content[currentPosition + 1];
                if (cNewChar == c)
                {
                    result = true;
                }
            }
            else
            {
                result = this.Children.Any(e => e.Content[0] == c);
            }
            return result;
        }

        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        public override UFIDAAbstractMatchNode GetChild(char c)
        {
            UFIDAAbstractMatchNode node = null;
            if (this.MoveToNextPosition())
            {
                if (this.CurrentChar == c)
                {
                    node = this;
                }
            }
            else
            {
                if (this.Children.Any(e => e.Content[0] == c))
                {
                    node = this.Children.First(e => e.Content[0] == c);
                    node.ResetPosition();
                }
            }
            return node;
        }
    }
}
