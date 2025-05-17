using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int left = 0, right = 0, maxLength = 0;
        HashSet<char> seen = new HashSet<char>();

        while (right < s.Length) {
            if (!seen.Contains(s[right])) {
                seen.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            } else {
                seen.Remove(s[left]);
                left++;
            }
        }

        return maxLength;
    }
}
