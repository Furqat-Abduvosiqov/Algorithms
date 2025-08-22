namespace LeetCode;

public class FindMaxArea
{
    /// <summary>
    /// Using Two pointer approach and moving smallest one.
    /// </summary>
    public int MaxArea(int[] height) {
        
        int left = 0;
        int right = height.Length - 1;
        
        int maxArea = 0;

        while (left < right) {
            
            int h = Math.Min(height[left], height[right]);
            
            int width = right - left;
            
            int area = h * width;
            
            maxArea = Math.Max(maxArea, area);

            // Move the shorter pointer inward
            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }

        return maxArea;
    }
}