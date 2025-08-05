/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
*/

using System;
using System.Collections.Generic;

public class Solution
{
    // Devuelve los índices de los dos números que suman 'target'
    public int[] TwoSum(int[] nums, int target)
    {
        // Diccionario para almacenar número y su índice correspondiente
        var map = new Dictionary<int, int>();

        // Recorremos el array una sola vez (O(n))
        for (int i = 0; i < nums.Length; i++)
        {
            int complemento = target - nums[i];
            // ¿Hemos visto antes el complemento necesario?
            if (map.ContainsKey(complemento))
            {
                // Si sí, devolvemos los índices (en cualquier orden)
                return new int[] { map[complemento], i };
            }
            // Si no, guardamos el valor actual y su índice
            if (!map.ContainsKey(nums[i])) // Solo guarda el primer índice
                map[nums[i]] = i;
        }
        // Si no se encuentra solución (no debe pasar por constraints)
        throw new ArgumentException("No solution found");
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = solution.TwoSum(nums, target);

        Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");
        // Output: Indices: [0, 1]
    }
}
