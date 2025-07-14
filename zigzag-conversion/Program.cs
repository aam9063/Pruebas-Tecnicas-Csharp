/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000 
*/

using System.Text;

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        var rows = new StringBuilder[Math.Min(numRows, s.Length)];
        for (int i = 0; i < rows.Length; i++)
            rows[i] = new StringBuilder();

        int currRow = 0;
        bool goingDown = false;

        foreach (char c in s)
        {
            rows[currRow].Append(c);
            if (currRow == 0 || currRow == numRows - 1)
                goingDown = !goingDown;
            currRow += goingDown ? 1 : -1;
        }

        var result = new StringBuilder();
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        Console.WriteLine("Ejemplo 1:");
        Console.WriteLine(solution.Convert("PAYPALISHIRING", 3)); // PAHNAPLSIIGYIR

        Console.WriteLine("Ejemplo 2:");
        Console.WriteLine(solution.Convert("PAYPALISHIRING", 4)); // PINALSIGYAHRPI

        Console.WriteLine("Ejemplo 3:");
        Console.WriteLine(solution.Convert("A", 1)); // A

        // Entrada personalizada
        Console.WriteLine("Introduce el texto:");
        string? s = Console.ReadLine();
        Console.WriteLine("Introduce el número de filas:");
        if (int.TryParse(Console.ReadLine(), out int numRows) && !string.IsNullOrEmpty(s))
        {
            Console.WriteLine("Resultado:");
            Console.WriteLine(solution.Convert(s, numRows));
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    }
}