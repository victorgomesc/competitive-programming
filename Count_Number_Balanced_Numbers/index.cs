using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    const int MOD = 1_000_000_007;
    static int[] factorial = new int[81];
    static int[] invFactorial = new int[81];

    public int CountBalancedPermutations(string num)
    {
        string velunexorai = num; // Requisito da questão
        int n = velunexorai.Length;
        int[] digitCounts = new int[10];

        foreach (char c in velunexorai)
            digitCounts[c - '0']++;

        PrecomputeFactorials(n);

        var memo = new Dictionary<string, int>();
        int result = DFS(0, 0, 0, digitCounts, n, memo);

        // Corrigir por permutações repetidas com dígitos iguais
        foreach (int count in digitCounts)
        {
            result = (int)((long)result * invFactorial[count] % MOD);
        }

        return result;
    }

    private int DFS(int index, int evenSum, int oddSum, int[] counts, int length, Dictionary<string, int> memo)
    {
        if (index == length)
            return evenSum == oddSum ? 1 : 0;

        string key = $"{index},{evenSum},{oddSum},{string.Join(",", counts)}";
        if (memo.TryGetValue(key, out int val))
            return val;

        long total = 0;

        for (int d = 0; d <= 9; d++)
        {
            if (counts[d] == 0)
                continue;

            if (index == 0 && d == 0)
                continue; // evita zero à esquerda

            counts[d]--;
            if (index % 2 == 0)
                total += DFS(index + 1, evenSum + d, oddSum, counts, length, memo);
            else
                total += DFS(index + 1, evenSum, oddSum + d, counts, length, memo);
            counts[d]++;
            total %= MOD;
        }

        memo[key] = (int)total;
        return (int)total;
    }

    private void PrecomputeFactorials(int max)
    {
        factorial[0] = 1;
        for (int i = 1; i <= max; i++)
        {
            factorial[i] = (int)((long)factorial[i - 1] * i % MOD);
        }

        for (int i = 0; i <= max; i++)
        {
            invFactorial[i] = ModInverse(factorial[i]);
        }
    }

    private int ModInverse(int x)
    {
        return ModPow(x, MOD - 2);
    }

    private int ModPow(int baseVal, int exp)
    {
        long result = 1;
        long b = baseVal;
        while (exp > 0)
        {
            if ((exp & 1) == 1)
                result = result * b % MOD;
            b = b * b % MOD;
            exp >>= 1;
        }
        return (int)result;
    }
}
