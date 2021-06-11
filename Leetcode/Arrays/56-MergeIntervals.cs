https://leetcode.com/problems/merge-intervals/
// 56 : Merge Intervals
// Difficulty : Medium
public class Solution {
    public int[][] Merge(int[][] intervals) {
        if(intervals.Length <= 1)
            return intervals;
        
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
        List<int[]> results = new List<int[]>();
        results.Add(intervals[0]);
        
        for(int i = 1; i < intervals.Length; i++)
        {
            int[] currInterval = results[results.Count - 1];
            if(currInterval[1] >= intervals[i][0])
            {
                 if(currInterval[1] >= intervals[i][1])
                     continue;
                currInterval[1] = intervals[i][1];
            }
            else
                results.Add(intervals[i]);
        }
        
        return results.ToArray();
    }
}