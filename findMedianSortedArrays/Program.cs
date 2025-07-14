/*
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
*/

class Program
{
    static void Main()
    {
        // Ejemplo 1
        int[] nums1 = { 1, 3 };
        int[] nums2 = { 2 };
        Console.WriteLine($"Median: {FindMedianSortedArrays(nums1, nums2):F5}");

        // Ejemplo 2
        nums1 = new int[] { 1, 2 };
        nums2 = new int[] { 3, 4 };
        Console.WriteLine($"Median: {FindMedianSortedArrays(nums1, nums2):F5}");

        // Puedes agregar más pruebas aquí si lo deseas
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);

        int m = nums1.Length;
        int n = nums2.Length;
        int imin = 0, imax = m, halfLen = (m + n + 1) / 2;

        while (imin <= imax)
        {
            int i = (imin + imax) / 2;
            int j = halfLen - i;

            if (i < m && nums2[j - 1] > nums1[i])
            {
                imin = i + 1;
            }
            else if (i > 0 && nums1[i - 1] > nums2[j])
            {
                imax = i - 1;
            }
            else
            {
                int maxOfLeft;
                if (i == 0) { maxOfLeft = nums2[j - 1]; }
                else if (j == 0) { maxOfLeft = nums1[i - 1]; }
                else { maxOfLeft = Math.Max(nums1[i - 1], nums2[j - 1]); }

                if ((m + n) % 2 == 1)
                    return maxOfLeft;

                int minOfRight;
                if (i == m) { minOfRight = nums2[j]; }
                else if (j == n) { minOfRight = nums1[i]; }
                else { minOfRight = Math.Min(nums1[i], nums2[j]); }

                return (maxOfLeft + minOfRight) / 2.0;
            }
        }

        throw new ArgumentException("Input arrays are not valid.");
    }
}