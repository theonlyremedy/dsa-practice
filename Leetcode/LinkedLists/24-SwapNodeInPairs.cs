// https://leetcode.com/problems/swap-nodes-in-pairs/
// 24 : Swap Nodes in Pairs
// Difficulty : Medium
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null)
            return head;
        
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode current = dummy;
        
        while(current.next != null && current.next.next != null)
        {
            ListNode first = current.next;
            ListNode second = current.next.next;
            first.next = second.next;
            second.next = first;
            current.next = second;
            current = current.next.next;
        }
        
        return dummy.next;
    }
}