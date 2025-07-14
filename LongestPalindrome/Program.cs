/*
Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
*/

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Introduce una cadena:");
        string? s = Console.ReadLine();

        if (!string.IsNullOrEmpty(s))
        {
            string resultado = LongestPalindrome(s);
            Console.WriteLine($"El substring palindrómico más largo es: {resultado}");
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    }

    public static string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length < 1)
            return "";

        int start = 0, end = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int len1 = ExpandAroundCenter(s, i, i);
            int len2 = ExpandAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);

            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    private static int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }
}