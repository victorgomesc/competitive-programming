using System;
using System.Collections.Generic;

public class Solution
{
    public int MaxRemoval(int[] nums, int[][] queries) 
    {
        int n = nums.Length, q = queries.Length;
        int[] coverage = new int[n];
        int[] diff = new int[n + 1];

        foreach (var query in queries)
        {
            diff[query[0]] += 1;
            diff[query[1] + 1] -= 1;
        }

        coverage[0] = diff[0];
        for (int i = 1; i < n; i++)
            coverage[i] = coverage[i - 1] + diff[i];

        for (int i = 0; i < n; i++)
        {
            if (coverage[i] < nums[i])
                return -1;
        }

        int left = 0, right = q, answer = 0;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (CanRemove(nums, queries, mid))
            {
                answer = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return answer;
    }

    private bool CanRemove(int[] nums, int[][] queries, int removeCount)
    {
        int n = nums.Length;
        int[] diff = new int[n + 1];

        for (int i = removeCount; i < queries.Length; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            diff[l] += 1;
            if (r + 1 < diff.Length)
                diff[r + 1] -= 1;
        }

        int[] cov = new int[n];
        cov[0] = diff[0];
        for (int i = 1; i < n; i++)
            cov[i] = cov[i - 1] + diff[i];

        for (int i = 0; i < n; i++)
        {
            if (cov[i] < nums[i])
                return false;
        }

        return true;
    }
}
