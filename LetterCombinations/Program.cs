/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the 
number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does 
not map to any letters.

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
Example 2:

Input: digits = ""
Output: []
Example 3:

Input: digits = "2"
Output: ["a","b","c"]
 
Constraints:

0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
*/

using System.Text;

public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(digits)) return result;

        string[] mapping = new string[]
        {
            "",     // 0
            "",     // 1
            "abc",  // 2
            "def",  // 3
            "ghi",  // 4
            "jkl",  // 5
            "mno",  // 6
            "pqrs", // 7
            "tuv",  // 8
            "wxyz"  // 9
        };

        void Backtrack(int index, StringBuilder path)
        {
            if (index == digits.Length)
            {
                result.Add(path.ToString());
                return;
            }

            string letters = mapping[digits[index] - '0'];
            foreach (char c in letters)
            {
                path.Append(c);
                Backtrack(index + 1, path);
                path.Length--; // backtrack
            }
        }

        Backtrack(0, new StringBuilder());
        return result;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        string digits = "23";
        IList<string> combinations = solution.LetterCombinations(digits);
        Console.WriteLine($"Combinaciones posibles: {string.Join(", ", combinations)}");
    }
}
