/*
Given the head of a linked list, remove the nth node from the end of the list and return its head.

Example 1:

Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
Example 2:

Input: head = [1], n = 1
Output: []
Example 3:

Input: head = [1,2], n = 1
Output: [1]
 
Constraints:

The number of nodes in the list is sz.
1 <= sz <= 30
0 <= Node.val <= 100
1 <= n <= sz
 
Follow up: Could you do this in one pass?
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode? RemoveNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(0, head);
        var fast = dummy;
        var slow = dummy;

        for (int i = 0; i <= n; i++)
            fast = fast.next!; // '!' asegura al compilador que no es null en este contexto

        while (fast != null) {
            fast = fast.next;
            slow = slow.next!;
        }

        // Aquí, slow.next no debería ser null nunca (por constraints del problema)
        slow.next = slow.next!.next;

        return dummy.next;
    }
}

class Program
{
    static void Main()
    {
        // Crear una lista de ejemplo: 1 -> 2 -> 3 -> 4 -> 5
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        int n = 2; // Eliminar el segundo nodo desde el final

        Solution solution = new Solution();
        ListNode? result = solution.RemoveNthFromEnd(head, n);

        // Imprimir la lista resultante
        while (result != null) {
            Console.Write(result.val + " ");
            result = result.next;
        }
    }
}