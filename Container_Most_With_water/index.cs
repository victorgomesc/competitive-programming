public class Solution {
    public int MaxArea(int[] height) {
        int maxArea = 0;
        int left = 0, right = height.Length - 1;

        while (left < right) {
            int h = Math.Min(height[left], height[right]);
            int width = right - left;
            int area = h * width;
            maxArea = Math.Max(maxArea, area);

            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }

        return maxArea;
    }
}
