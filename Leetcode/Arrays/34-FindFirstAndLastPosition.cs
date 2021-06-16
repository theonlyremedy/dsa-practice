// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
// 34 : Find First and Last Position of Element in Sorted Array
// Difficulty : Medium
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int leftIndex = BinarySearch(nums, target);
        if(leftIndex == nums.Length || nums[leftIndex] != target)
            return new int[] { -1, -1 };
        int rightIndex = BinarySearch(nums, target + 1) - 1;
        return new int[] {leftIndex, rightIndex};
    }
    
    public int BinarySearch(int[] nums, int target)
    {
        int left = 0, right = nums.Length;
        while(left < right)
        {
            int mid = left + ((right-left) >> 1);
            if(nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }
        
        return left;
    }
}