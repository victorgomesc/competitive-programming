using System;
using System.Collections.Generic;

public class Solution
{
    private int[] nums;
    private int k;
    private List<int>[] graph;

    public int MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        this.nums = nums;
        this.k = k;
        int n = nums.Length;

        graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var result = Dfs(0, -1);

        return result.Item1;
    }

    private Tuple<int, int> Dfs(int node, int parent)
    {
        int noChange = nums[node];
        int withChange = nums[node] ^ k;

        foreach (int neighbor in graph[node])
        {
            if (neighbor == parent) continue;

            var child = Dfs(neighbor, node);
            int newNoChange = Math.Max(noChange + child.Item1, withChange + child.Item2);
            int newWithChange = Math.Max(noChange + child.Item2, withChange + child.Item1);
            noChange = newNoChange;
            withChange = newWithChange;
        }

        return Tuple.Create(noChange, withChange);
    }
}
