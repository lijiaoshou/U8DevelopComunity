﻿using System.Collections.Generic;

namespace U8.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 抽象匹配节点
    /// </summary>
    public abstract class U8AbstractMatchNode : U8IMatchNode
    {
        /// <summary>
        /// 当前字符
        /// </summary>
        public virtual char CurrentChar
        {
            get { return this.Content[currentPosition]; }
        }

        /// <summary>
        /// 匹配关键字
        /// </summary>
        protected List<string> matchKeywords = new List<string>();

        /// <summary>
        /// 匹配关键字
        /// </summary>
        public IEnumerable<string> MatchKeywords
        {
            get { return matchKeywords; }
        }

        /// <summary>
        /// 失效点
        /// </summary>
        protected List<U8FailOverNode> failovers = new List<U8FailOverNode>();

        /// <summary>
        /// 失效点
        /// </summary>
        public IEnumerable<U8FailOverNode> Failovers
        {
            get { return failovers; }
        }

        /// <summary>
        /// 父节点
        /// </summary>
        public U8AbstractMatchNode Parent { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        protected List<U8AbstractMatchNode> children = new List<U8AbstractMatchNode>();

        /// <summary>
        /// 子节点
        /// </summary>
        public IEnumerable<U8AbstractMatchNode> Children
        {
            get { return children; }
        }

        /// <summary>
        /// 当前位置
        /// </summary>
        protected int currentPosition = 0;

        /// <summary>
        /// 当前位置
        /// </summary>
        public int CurrentPosition
        {
            get { return currentPosition; }
        }

        /// <summary>
        /// 移动到下一个位置
        /// </summary>
        /// <returns>结果</returns>
        public virtual bool MoveToNextPosition()
        {
            bool result = false;
            if (currentPosition < (this.Content.Length - 1))
            {
                currentPosition++;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 重置位置
        /// </summary>
        public virtual void ResetPosition()
        {
            currentPosition = 0;
        }

        /// <summary>
        /// 设置位置
        /// </summary>
        /// <param name="position">位置</param>
        public virtual void SetPosition(int position)
        {
            currentPosition = position;
        }

        /// <summary>
        /// 当前失效点
        /// </summary>
        public virtual U8FailOverNode CurrentFailover
        {
            get
            {
                return this.failovers[currentPosition];
            }
            set
            {
                failovers[currentPosition] = value;
            }
        }

        /// <summary>
        /// 设置待匹配的关键字到列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        public virtual void SetKeyword(string keyword)
        {
            this.matchKeywords[currentPosition] = keyword;
        }

        /// <summary>
        /// 当前的关键字
        /// </summary>
        public virtual string CurrentKeyword
        {
            get { return this.matchKeywords[currentPosition]; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 增加字符
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        public abstract U8AbstractMatchNode AddChar(char c);

        /// <summary>
        /// 父级失效点
        /// </summary>
        public abstract U8FailOverNode ParentFailover { get; }

        /// <summary>
        /// 判断是否有子节点
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        public abstract bool HasChild(char c);

        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        public abstract U8AbstractMatchNode GetChild(char c);

        /// <summary>
        /// 找到失效点
        /// </summary>
        /// <param name="rootNode">根</param>
        public abstract void MatchFailOver(U8AbstractMatchNode rootNode);

        /// <summary>
        /// 设置失效点
        /// </summary>
        /// <param name="offset">偏移量</param>
        /// <param name="failOverNode">失效点</param>
        public void SetFailover(int offset, U8FailOverNode failOverNode)
        {
            failovers[offset] = failOverNode;
        }
    }
}
