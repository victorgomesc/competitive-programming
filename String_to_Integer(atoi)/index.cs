public class Solution {
    public int MyAtoi(string s) {
        if (string.IsNullOrEmpty(s)) return 0;

        int i = 0;
        int n = s.Length;
        int result = 0;
        int sign = 1;

        while (i < n && s[i] == ' ') i++;

        if (i < n && (s[i] == '-' || s[i] == '+')) {
            sign = s[i] == '-' ? -1 : 1;
            i++;
        }

        while (i < n && char.IsDigit(s[i])) {
            int digit = s[i] - '0';

            if (result > (Int32.MaxValue - digit) / 10) {
                return sign == 1 ? Int32.MaxValue : Int32.MinValue;
            }

            result = result * 10 + digit;
            i++;
        }

        return result * sign;
    }
}
