/*
 Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.

k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.

You may not alter the values in the list's nodes, only nodes themselves may be changed.

Example 1:

Input: head = [1,2,3,4,5], k = 2
Output: [2,1,4,3,5]
Example 2:

Input: head = [1,2,3,4,5], k = 3
Output: [3,2,1,4,5]
 
Constraints:

The number of nodes in the list is n.
1 <= k <= n <= 5000
0 <= Node.val <= 1000
 
Follow-up: Can you solve the problem in O(1) extra memory space?
*/

public class Solution
{
    public ListNode? ReverseKGroup(ListNode? head, int k)
    {
        if (head == null || k == 1) return head;

        var dummy = new ListNode(0, head);
        var prevGroup = dummy;

        while (true)
        {
            // Busca el k-ésimo nodo desde prevGroup
            var kth = prevGroup;
            for (int i = 0; i < k && kth != null; i++)
                kth = kth.next;
            if (kth == null) break; // No hay suficientes nodos para invertir

            var groupEnd = kth.next;
            var prev = groupEnd;
            var curr = prevGroup.next;

            // Invierte el grupo de k nodos
            for (int i = 0; i < k; i++)
            {
                var temp = curr!.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            // Reconecta el grupo invertido con el resto de la lista
            var tempGroupStart = prevGroup.next;
            prevGroup.next = prev;
            prevGroup = tempGroupStart!;
        }

        return dummy.next;
    }
}

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

class Program
{
    static ListNode? BuildList(int[] arr)
    {
        var dummy = new ListNode();
        var tail = dummy;
        foreach (var v in arr)
        {
            tail.next = new ListNode(v);
            tail = tail.next;
        }
        return dummy.next;
    }

    static void PrintList(ListNode? head)
    {
        while (head != null)
        {
            Console.Write(head.val + (head.next != null ? " -> " : ""));
            head = head.next;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        var list = BuildList(new[] { 1, 2, 3, 4, 5 });
        int k = 2; // Cambia a 3 para el otro ejemplo

        var solution = new Solution();
        var result = solution.ReverseKGroup(list, k);

        PrintList(result); // Output para k=2: 2 -> 1 -> 4 -> 3 -> 5
    }
}
