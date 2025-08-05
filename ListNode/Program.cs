/*
 Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

Example 1:

Input: head = [1,2,3,4]

Output: [2,1,4,3]

Explanation:


Example 2:

Input: head = []

Output: []

Example 3:

Input: head = [1]

Output: [1]

Example 4:

Input: head = [1,2,3]

Output: [2,1,3]

Constraints:

The number of nodes in the list is in the range [0, 100].
0 <= Node.val <= 100
 */

// Definición de ListNode (puedes tenerla en un archivo aparte)
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

// Solución óptima: O(n) tiempo, O(1) memoria adicional
public class Solution
{
    public ListNode? SwapPairs(ListNode? head)
    {
        var dummy = new ListNode(0, head);
        var prev = dummy;

        // Itera mientras haya al menos dos nodos siguientes
        while (prev.next != null && prev.next.next != null)
        {
            var first = prev.next;
            var second = first.next;

            // Intercambia los nodos
            first.next = second!.next;
            second.next = first;
            prev.next = second;

            // Avanza dos posiciones
            prev = first;
        }

        return dummy.next;
    }
}

class Program
{
    // Construye una lista enlazada desde un array
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

    // Imprime la lista enlazada por consola
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
        var list = BuildList(new[] { 1, 2, 3, 4 });
        var solution = new Solution();
        var swapped = solution.SwapPairs(list);

        PrintList(swapped); // Output: 2 -> 1 -> 4 -> 3
    }
}
