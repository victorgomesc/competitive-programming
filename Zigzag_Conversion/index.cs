public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1 || s.Length <= numRows) return s;

        List<string> rows = new List<string>(new string[Math.Min(numRows, s.Length)]);
        int currRow = 0;
        bool goingDown = false;

        foreach (char c in s) {
            rows[currRow] += c;
            if (currRow == 0 || currRow == numRows - 1)
                goingDown = !goingDown;

            currRow += goingDown ? 1 : -1;
        }

        return string.Join("", rows);
    }
}
