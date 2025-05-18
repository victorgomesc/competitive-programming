public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.Length > nums2.Length) {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int totalLeft = (m + n + 1) / 2;

        int left = 0, right = m;
        while (left <= right) {
            int i = (left + right) / 2;
            int j = totalLeft - i;

            int maxLeft1 = (i == 0) ? int.MinValue : nums1[i - 1];
            int minRight1 = (i == m) ? int.MaxValue : nums1[i];

            int maxLeft2 = (j == 0) ? int.MinValue : nums2[j - 1];
            int minRight2 = (j == n) ? int.MaxValue : nums2[j];

            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1) {
                if ((m + n) % 2 == 0) {
                    return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                } else {
                    return Math.Max(maxLeft1, maxLeft2);
                }
            } else if (maxLeft1 > minRight2) {
                right = i - 1;
            } else {
                left = i + 1;
            }
        }

        throw new ArgumentException("Input arrays are not sorted properly.");
    }
}
