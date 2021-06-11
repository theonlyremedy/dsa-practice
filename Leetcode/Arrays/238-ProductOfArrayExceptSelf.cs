// https://leetcode.com/problems/product-of-array-except-self/
// 238 : Product of Array Except Self
// Difficulty : Medium
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] prefix = new int[nums.Length];
        int[] suffix = new int[nums.Length];
        int[] result = new int[nums.Length];
        int prefixProd = 1, suffixProd = 1;
        
        for(int i = 0, j = nums.Length - 1; i < nums.Length && j >= 0; i++, j--)
        {
            prefix[i] = prefixProd;
            prefixProd *= nums[i];
            
            suffix[j] = suffixProd;
            suffixProd *= nums[j];
        }
        
        for(int k = 0; k < nums.Length; k++)
            result[k] = prefix[k] * suffix[k];
        
        return result;
    }
}