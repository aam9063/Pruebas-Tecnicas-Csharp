/*
Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.

Return the sum of the three integers.

You may assume that each input would have exactly one solution.

Example 1:

Input: nums = [-1,2,1,-4], target = 1
Output: 2
Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
Example 2:

Input: nums = [0,0,0], target = 1
Output: 0
Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).
 
Constraints:

3 <= nums.length <= 500
-1000 <= nums[i] <= 1000
-104 <= target <= 104
*/

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int closest = nums[0] + nums[1] + nums[2];

        for (int i = 0; i < n - 2; i++)
        {
            int left = i + 1, right = n - 1;
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (Math.Abs(sum - target) < Math.Abs(closest - target))
                {
                    closest = sum;
                }
                if (sum < target)
                {
                    left++;
                }
                else if (sum > target)
                {
                    right--;
                }
                else
                {
                    // Exact match
                    return sum;
                }
            }
        }
        return closest;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] nums = { -1, 2, 1, -4 };
        int target = 1;
        int result = solution.ThreeSumClosest(nums, target);
        Console.WriteLine($"La suma más cercana al objetivo es: {result}");
    }
}