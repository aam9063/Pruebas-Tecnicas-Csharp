/*
 Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
 */

class Program
{
       static void Main()
    {
        string[] examples = {
            "abcabcbb",
            "bbbbb",
            "pwwkew",
            "dvdf",
            "anviaj"
        };
        foreach (var text in examples)
        {
            Console.WriteLine($"Input: {text}");
            Console.WriteLine($"Output: {LengthOfLongestSubstring(text)}");
            Console.WriteLine(new string('-', 20));
        }
    }
    static int LengthOfLongestSubstring(string s)
    {
        var charIndexMap = new Dictionary<char, int>();
        int maxLength = 0, start = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (charIndexMap.ContainsKey(s[i]) && charIndexMap[s[i]] >= start)
            {
                start = charIndexMap[s[i]] + 1;
            }
            charIndexMap[s[i]] = i;
            maxLength = Math.Max(maxLength, i - start + 1);
        }
        return maxLength;
    }
}