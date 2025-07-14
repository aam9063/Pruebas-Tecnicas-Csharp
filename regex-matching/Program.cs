/*
Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
 
Constraints:

1 <= s.length <= 20
1 <= p.length <= 20
s contains only lowercase English letters.
p contains only lowercase English letters, '.', and '*'.
It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
*/

public class Solution
{
    public bool IsMatch(string s, string p)
    {
        bool[,] dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;

        for (int j = 1; j <= p.Length; j++)
        {
            if (p[j - 1] == '*')
            {
                dp[0, j] = dp[0, j - 2];
            }
        }

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= p.Length; j++)
            {
                if (p[j - 1] == s[i - 1] || p[j - 1] == '.')
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i, j - 2] || (dp[i - 1, j] && (s[i - 1] == p[j - 2] || p[j - 2] == '.'));
                }
            }
        }

        return dp[s.Length, p.Length];
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        Console.WriteLine("Ejemplo 1:");
        Console.WriteLine(solution.IsMatch("aa", "a")); // false

        Console.WriteLine("Ejemplo 2:");
        Console.WriteLine(solution.IsMatch("aa", "a*")); // true

        Console.WriteLine("Ejemplo 3:");
        Console.WriteLine(solution.IsMatch("ab", ".*")); // true
    }
}