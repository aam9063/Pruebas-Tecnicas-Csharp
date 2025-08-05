/*
You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

Example 1:

Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]
 
Constraints:

The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both list1 and list2 are sorted in non-decreasing order.
*/

// Definición del nodo de lista enlazada (puedes ponerla en un archivo aparte si lo prefieres)
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

// Solución óptima
public class Solution
{
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        ListNode dummy = new ListNode(-1);
        ListNode tail = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }
            tail = tail.next;
        }
        tail.next = list1 ?? list2;
        return dummy.next;
    }
}

// Clase Program preparada para probar en consola
class Program
{
    // Método auxiliar para construir una lista enlazada a partir de un array
    static ListNode? BuildList(int[] arr)
    {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;
        foreach (int val in arr)
        {
            tail.next = new ListNode(val);
            tail = tail.next;
        }
        return dummy.next;
    }

    // Método para imprimir una lista enlazada en consola
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
        // Ejemplo de uso
        var list1 = BuildList(new[] { 1, 2, 4 });
        var list2 = BuildList(new[] { 1, 3, 4 });

        var solution = new Solution();
        var merged = solution.MergeTwoLists(list1, list2);

        PrintList(merged); // Output: 1 -> 1 -> 2 -> 3 -> 4 -> 4
    }
}

