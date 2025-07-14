/*
Given an integer x, return true if x is a palindrome, and false otherwise.

Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 
Constraints:

-231 <= x <= 231 - 1
 
Follow up: Could you solve it without converting the integer to a string?
*/

public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;

        int reversed = 0;
        while (x > reversed)
        {
            reversed = reversed * 10 + x % 10;
            x /= 10;
        }

        return x == reversed || x == reversed / 10;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        Console.WriteLine("Ejemplo 1:");
        Console.WriteLine(solution.IsPalindrome(121)); // true

        Console.WriteLine("Ejemplo 2:");
        Console.WriteLine(solution.IsPalindrome(-121)); // false

        Console.WriteLine("Ejemplo 3:");
        Console.WriteLine(solution.IsPalindrome(10)); // false
    }
}