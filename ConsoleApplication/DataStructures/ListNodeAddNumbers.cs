using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.DataStructures
{
    //https://leetcode.com/problems/add-two-numbers/submissions/
    public class ListNodeAddNumbers
    {
        public static void run()
        {
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            //var sum= new ListNodeAddNumbers().AddTwoNumbers(l1, l2);
            var sum = new ListNodeAddNumbers().addTwoNumbersS(l1, l2);
            Console.WriteLine(getAllNodes(sum));
        }

        public ListNode addTwoNumbersS(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dl1 = getAllNodes(l1);
            string total = (int.Parse(dl1) + int.Parse(getAllNodes(l2))).ToString();
            Console.WriteLine("Total" + total);
            ListNode root = null, nextNode = null;
            for (int i = total.Length - 1; i >= 0; i--)
            {
                if (root == null)
                {
                    root = new ListNode(int.Parse(total[i].ToString()));
                }
                else
                {
                       nextNode = new ListNode(int.Parse(total[i].ToString()));
                }
            }
            return root;
        }

        static string getAllNodes(ListNode l, StringBuilder n = null)
        {
            n = n ?? new StringBuilder();
            Console.WriteLine(n.ToString());
            if (l.next == null)
            {
                n.Insert(0, l.val.ToString());
                Console.WriteLine(n.ToString());
                return n.ToString();
            }
            else
                n.Insert(0,l.val.ToString());
            //n.Append(l.val.ToString(), 0, l.val.ToString().Length);
            return getAllNodes(l.next,n);
        }
    }


    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
