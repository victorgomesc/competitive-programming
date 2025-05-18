public class Solution {
    private const int MOD = 1000000007;

    public int ColorTheGrid(int m, int n) {
        var validStates = new List<int[]>();
        GenerateValidStates(m, new List<int>(), validStates);

        var stateToIndex = new Dictionary<string, int>();
        for (int i = 0; i < validStates.Count; i++) {
            stateToIndex[string.Join(",", validStates[i])] = i;
        }

        var compatible = new List<int>[validStates.Count];
        for (int i = 0; i < validStates.Count; i++) {
            compatible[i] = new List<int>();
            for (int j = 0; j < validStates.Count; j++) {
                if (IsCompatible(validStates[i], validStates[j])) {
                    compatible[i].Add(j);
                }
            }
        }

        int[,] dp = new int[n, validStates.Count];
        for (int i = 0; i < validStates.Count; i++) {
            dp[0, i] = 1;
        }

        for (int col = 1; col < n; col++) {
            for (int curr = 0; curr < validStates.Count; curr++) {
                foreach (var prev in compatible[curr]) {
                    dp[col, curr] = (dp[col, curr] + dp[col - 1, prev]) % MOD;
                }
            }
        }

        int result = 0;
        for (int i = 0; i < validStates.Count; i++) {
            result = (result + dp[n - 1, i]) % MOD;
        }
        return result;
    }

    private void GenerateValidStates(int m, List<int> current, List<int[]> result) {
        if (current.Count == m) {
            result.Add(current.ToArray());
            return;
        }

        for (int color = 0; color < 3; color++) {
            if (current.Count == 0 || current[^1] != color) {
                current.Add(color);
                GenerateValidStates(m, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsCompatible(int[] a, int[] b) {
        for (int i = 0; i < a.Length; i++) {
            if (a[i] == b[i]) return false;
        }
        return true;
    }
}
