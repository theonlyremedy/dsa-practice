// https://leetcode.com/problems/count-pairs-in-two-arrays/
// 1885 : Count Pairs in Two Arrays
// Difficulty : Medium
public class Solution {
    public long CountPairs(int[] nums1, int[] nums2) {
        for(int index = 0; index < nums1.Length; index++)
            nums1[index] = nums1[index] - nums2[index];
        
        Array.Sort(nums1);
        
        long left = 0, right = nums1.Length - 1, count = 0;
        while(left < right)
        {
            if(nums1[left] + nums1[right] <= 0)
                left++;
            else
            {
                count += (right - left);
                right--;
            }
        }
        
        return count;
    }
}