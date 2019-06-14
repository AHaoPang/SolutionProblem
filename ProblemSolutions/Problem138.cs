using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem138 : IProblem
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }

        public void RunProblem()
        {
            Node n1 = new Node();
            n1.val = 1;

            Node n2 = new Node();
            n2.val = 2;

            n1.next = n2;
            n1.random = n2;

            n2.random = n2;

            var temp = CopyRandomList(n1);
        }

        public Node CopyRandomList(Node head)
        {
            /*
             * 深度拷贝一个带随机指针的链表
             * 思路：
             *  1.分析下带随机指针的链表，它有且只有一个主链表，然后就是随机的指针了；
             *  2.如果是单链表，那么问题的处理很简单很多~，现在加上了一个随机指针~
             *  3.考虑先复制主链表，并建立新旧链表地址的映射关系，再复制随机指针
             *  
             * 时间复杂度：O(n)，总共需要遍历两次链表
             * 空间复杂度：O(n)，我们要建立每个地址的映射关系
             */

            //复制主链表，并建立映射关系
            Node newHead = new Node();
            Node newHeadTail = newHead;

            Dictionary<Node, Node> dicOldToNewNode = new Dictionary<Node, Node>();

            Node oldHead = new Node();
            oldHead.next = head;

            Node oldHeadTail = oldHead;
            while (oldHeadTail.next != null)
            {
                oldHeadTail = oldHeadTail.next;

                var newTemp = new Node();
                newTemp.val = oldHeadTail.val;

                newHeadTail.next = newTemp;
                newHeadTail = newHeadTail.next;

                dicOldToNewNode[oldHeadTail] = newTemp;
            }

            oldHeadTail = oldHead;
            newHeadTail = newHead;
            while (oldHeadTail.next != null)
            {
                oldHeadTail = oldHeadTail.next;
                newHeadTail = newHeadTail.next;

                if (oldHeadTail.random != null) newHeadTail.random = dicOldToNewNode[oldHeadTail.random];
            }

            return newHead.next;
        }
    }
}
