/*
You are given a string s and an array of strings words. All the strings of words are of the same length.

A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]

Output: [0,9]

Explanation:

The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.

Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]

Output: []

Explanation:

There is no concatenated substring.

Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]

Output: [6,9,12]

Explanation:

The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"].
The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"].
The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"].

Constraints:

1 <= s.length <= 104
1 <= words.length <= 5000
1 <= words[i].length <= 30
s and words[i] consist of lowercase English letters.
*/

public class Solution
{
    // Devuelve los índices de todas las substrings que son concatenaciones de 'words'
    public IList<int> FindSubstring(string s, string[] words)
    {
        var result = new List<int>();
        if (s == null || words == null || words.Length == 0) return result;

        int wordLen = words[0].Length;
        int totalWords = words.Length;
        int concatLen = wordLen * totalWords;

        if (s.Length < concatLen) return result;

        // Conteo de ocurrencias de cada palabra
        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
            wordCount[word] = wordCount.GetValueOrDefault(word, 0) + 1;

        // Probamos cada posible offset de 0 a wordLen-1
        for (int offset = 0; offset < wordLen; offset++)
        {
            int left = offset, count = 0;
            var seen = new Dictionary<string, int>();
            for (int right = offset; right + wordLen <= s.Length; right += wordLen)
            {
                string curr = s.Substring(right, wordLen);
                if (wordCount.ContainsKey(curr))
                {
                    seen[curr] = seen.GetValueOrDefault(curr, 0) + 1;
                    count++;

                    // Si la palabra se ha visto más veces de lo permitido, movemos left
                    while (seen[curr] > wordCount[curr])
                    {
                        string leftWord = s.Substring(left, wordLen);
                        seen[leftWord]--;
                        left += wordLen;
                        count--;
                    }
                    // Si tenemos todas las palabras, es una solución
                    if (count == totalWords)
                        result.Add(left);
                }
                else
                {
                    // Palabra no válida, reiniciamos ventana
                    seen.Clear();
                    count = 0;
                    left = right + wordLen;
                }
            }
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Prueba 1
        string s1 = "barfoothefoobarman";
        string[] words1 = { "foo", "bar" };
        var result1 = solution.FindSubstring(s1, words1);
        Console.WriteLine("Ejemplo 1: " + string.Join(", ", result1)); // Output: 0, 9

        // Prueba 2
        string s2 = "wordgoodgoodgoodbestword";
        string[] words2 = { "word", "good", "best", "word" };
        var result2 = solution.FindSubstring(s2, words2);
        Console.WriteLine("Ejemplo 2: " + string.Join(", ", result2)); // Output: (empty)

        // Prueba 3
        string s3 = "barfoofoobarthefoobarman";
        string[] words3 = { "bar", "foo", "the" };
        var result3 = solution.FindSubstring(s3, words3);
        Console.WriteLine("Ejemplo 3: " + string.Join(", ", result3)); // Output: 6, 9, 12
    }
}

