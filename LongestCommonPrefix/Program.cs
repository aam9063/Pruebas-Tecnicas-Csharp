/*
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 
Constraints:

1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lowercase English letters if it is non-empty.
*/

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return "";

        for (int i = 0; i < strs[0].Length; i++)
        {
            char c = strs[0][i];
            for (int j = 1; j < strs.Length; j++)
            {
                // Si la posición se sale de rango o hay una diferencia
                if (i >= strs[j].Length || strs[j][i] != c)
                    return strs[0].Substring(0, i);
            }
        }
        // Si llegamos hasta aquí, todo el primer string es prefijo común
        return strs[0];
    }
}


class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        string[] strs = { "flower", "flow", "flight" };
        string result = solution.LongestCommonPrefix(strs);
        Console.WriteLine($"El prefijo común más largo es: {result}");
    }
}