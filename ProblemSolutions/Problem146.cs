using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem146 : IProblem
    {
        public void RunProblem()
        {
            var lruCache = new LRUCache(2);
            lruCache.Put(1, 1);
            lruCache.Put(2, 2);

            var t = lruCache.Get(1);
            if (t != 1) throw new Exception();

            lruCache.Put(3, 3);
            t = lruCache.Get(2);
            if (t != -1) throw new Exception();

            lruCache.Put(4, 4);
            t = lruCache.Get(1);
            if (t != -1) throw new Exception();

            t = lruCache.Get(3);
            if (t != 3) throw new Exception();
            t = lruCache.Get(4);
            if (t != 4) throw new Exception();

            var lruCache2 = new LRUCache(1);
            lruCache2.Put(2, 1);

            t = lruCache2.Get(2);
            if (t != 1) throw new Exception();

            lruCache2.Put(3, 2);
            t = lruCache2.Get(2);
            if (t != -1) throw new Exception();

            t = lruCache2.Get(3);
            if (t != 2) throw new Exception();
        }

        /// <summary>
        /// LRU，在实现过程中，头指针使用的伪的，尾指针是实的，其实可以优化成尾也是伪的
        /// </summary>
        public class LRUCache
        {
            /// <summary>
            /// 初始化一个LRU对象
            /// </summary>
            public LRUCache(int capacity)
            {
                nodeDic = new Dictionary<int, DoubleLinkedNode>(capacity);

                m_Head = new DoubleLinkedNode(-1, -1);
                m_Capacity = capacity;
            }

            /// <summary>
            /// 获取对象
            /// </summary>
            public int Get(int key)
            {
                if (!nodeDic.ContainsKey(key)) return -1;

                var nodeTemp = nodeDic[key];
                UpdateNode(nodeTemp);

                return nodeTemp.Val;
            }

            /// <summary>
            /// 添加对象（若值不存在，才允许写入）
            /// </summary>
            public void Put(int key, int value)
            {
                if (nodeDic.ContainsKey(key))
                {
                    if (nodeDic[key].Val != value)
                    {
                        nodeDic[key].Val = value;
                        Get(key);
                    }
                    return;
                }
                nodeDic[key] = new DoubleLinkedNode(key, value);

                AddNode(nodeDic[key]);

                if (m_Count > m_Capacity)
                {
                    nodeDic.Remove(m_Tail.Key);
                    DelNode();
                }
            }

            private Dictionary<int, DoubleLinkedNode> nodeDic;

            #region DoubleLinked
            /// <summary>
            /// 双向链表节点
            /// </summary>
            class DoubleLinkedNode
            {
                public DoubleLinkedNode(int key, int val)
                {
                    Key = key;
                    Val = val;
                }

                public int Key { get; set; }

                public int Val { get; set; }

                public DoubleLinkedNode Prev { get; set; }

                public DoubleLinkedNode Next { get; set; }
            }

            /// <summary>
            /// 头节点，指向一个节点，但是此节点不存储值
            /// </summary>
            private DoubleLinkedNode m_Head { get; set; }

            /// <summary>
            /// 尾节点，双向链表中，最后一个值的存储位置
            /// </summary>
            private DoubleLinkedNode m_Tail { get; set; }

            /// <summary>
            /// 双向链表的限制容量
            /// </summary>
            private int m_Capacity { get; set; }

            /// <summary>
            /// 双向链表的当前容量
            /// </summary>
            private int m_Count { get; set; }

            /// <summary>
            /// 新增加一个节点
            /// </summary>
            private void AddNode(DoubleLinkedNode newNode)
            {
                newNode.Next = m_Head.Next;
                if (newNode.Next != null)
                    newNode.Next.Prev = newNode;
                else
                    m_Tail = newNode;

                m_Head.Next = newNode;
                newNode.Prev = m_Head;

                m_Count++;
            }

            /// <summary>
            /// 删除一个节点，依据数据结构，删除的一定是尾节点
            /// </summary>
            private void DelNode()
            {
                if (m_Tail == null) return;

                m_Tail = m_Tail.Prev;
                m_Tail.Next = null;

                m_Count--;
            }

            /// <summary>
            /// 更新一个节点，放在头节点的下一个位置
            /// </summary>
            private void UpdateNode(DoubleLinkedNode node)
            {
                node.Prev.Next = node.Next;
                if (node.Next != null)
                    node.Next.Prev = node.Prev;
                else if (m_Count != 1)
                    m_Tail = m_Tail.Prev;

                node.Next = m_Head.Next;
                if (node.Next != null)
                    node.Next.Prev = node;

                m_Head.Next = node;
                node.Prev = m_Head;
            }
            #endregion
        }
    }
}
