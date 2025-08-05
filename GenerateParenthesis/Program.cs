/*
 Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:

Input: n = 1
Output: ["()"]
 
Constraints:

1 <= n <= 8 public class
*/

using System.Text;

public class Solution
{
    // Genera todas las combinaciones válidas de paréntesis bien formados
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        Backtrack(result, new StringBuilder(), 0, 0, n);
        return result;
    }

    // Backtracking recursivo
    private void Backtrack(List<string> result, StringBuilder current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            result.Add(current.ToString());
            return;
        }

        if (open < max)
        {
            current.Append('(');
            Backtrack(result, current, open + 1, close, max);
            current.Length--; // Deshacer la última adición
        }

        if (close < open)
        {
            current.Append(')');
            Backtrack(result, current, open, close + 1, max);
            current.Length--; // Deshacer la última adición
        }
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();
        int n = 3;  // Cambiar valor de n para probar con diferentes entradas

        var results = solution.GenerateParenthesis(n);
        Console.WriteLine($"Todas las combinaciones de {n} pares de paréntesis:");
        foreach (var s in results)
        {
            Console.WriteLine(s);
        }
    }
}
