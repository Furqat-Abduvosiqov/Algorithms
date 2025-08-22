namespace LeetCode;

public class MergeTwoLists
{
    public class ListNode{
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
            this.val = val;
            this.next = next;
        }
    }
 
   
    public ListNode MergeTwoList(ListNode list1, ListNode list2) 
    {
        // Dummy/sentinel node to simplify head handling
        var dummy = new ListNode(0);
        var tail = dummy;

        var p1 = list1;
        var p2 = list2;

        while (p1 != null && p2 != null)
        {
            if (p1.val <= p2.val)
            {
                tail.next = p1;   // attach smaller (or equal) node
                p1 = p1.next;     // advance list1
            }
            else
            {
                tail.next = p2;   // attach smaller node
                p2 = p2.next;     // advance list2
            }
            tail = tail.next;     // move the tail forward
        }

        // Exactly one of p1 or p2 is non-null; attach the rest
        tail.next = p1 ?? p2;

        // The merged list starts at dummy.next
        return dummy.next; 
        
    }
}