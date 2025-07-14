/*
Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
 

Constraints:

-231 <= x <= 231 - 1
*/

public class Solution
{
    public int Reverse(int x)
    {
        int result = 0;
        while (x != 0)
        {
            int pop = x % 10;
            x /= 10;

            // Comprobar overflow antes de multiplicar por 10
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && pop > 7))
                return 0;
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && pop < -8))
                return 0;

            result = result * 10 + pop;
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        Console.WriteLine("Ejemplo 1: x = 123");
        Console.WriteLine(solution.Reverse(123)); // 321

        Console.WriteLine("Ejemplo 2: x = -123");
        Console.WriteLine(solution.Reverse(-123)); // -321

        Console.WriteLine("Ejemplo 3: x = 120");
        Console.WriteLine(solution.Reverse(120)); // 21

        // Entrada personalizada
        Console.WriteLine("Introduce un número entero:");
        if (int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Resultado:");
            Console.WriteLine(solution.Reverse(x));
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    }
}