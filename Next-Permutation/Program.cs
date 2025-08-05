/*
A permutation of an array of integers is an arrangement of its members into a sequence or linear order.

For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).

For example, the next permutation of arr = [1,2,3] is [1,3,2].
Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
Given an array of integers nums, find the next permutation of nums.

The replacement must be in place and use only constant extra memory.

Example 1:

Input: nums = [1,2,3]
Output: [1,3,2]
Example 2:

Input: nums = [3,2,1]
Output: [1,2,3]
Example 3:

Input: nums = [1,1,5]
Output: [1,5,1]

Constraints:

1 <= nums.length <= 100
0 <= nums[i] <= 100
*/

public class Solution
{
    // Modifica 'nums' para convertirlo en la siguiente permutación lexicográfica in-place
    public void NextPermutation(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return;

        // 1. Busca el primer elemento ascendente desde el final (pivote)
        int i = n - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        if (i >= 0)
        {
            // 2. Busca el siguiente mayor al pivote desde el final
            int j = n - 1;
            while (nums[j] <= nums[i])
                j--;
            // 3. Intercambia
            Swap(nums, i, j);
        }

        // 4. Invierte la parte después del pivote para dejarla en orden creciente
        Reverse(nums, i + 1, n - 1);
    }

    // Intercambia dos posiciones del array
    private void Swap(int[] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }

    // Invierte una subarray del array nums
    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        int[] nums1 = { 1, 2, 3 };
        solution.NextPermutation(nums1);
        Console.WriteLine(string.Join(", ", nums1)); // Output: 1, 3, 2

        int[] nums2 = { 3, 2, 1 };
        solution.NextPermutation(nums2);
        Console.WriteLine(string.Join(", ", nums2)); // Output: 1, 2, 3

        int[] nums3 = { 1, 1, 5 };
        solution.NextPermutation(nums3);
        Console.WriteLine(string.Join(", ", nums3)); // Output: 1, 5, 1
    }
}

