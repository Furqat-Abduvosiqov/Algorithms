namespace LeetCode;

public class LengthOfLongestSubstrings
{
    /*
      Given a string s, find the length of the longest substring without duplicate characters.
     */
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        int maxLen = 0, left = 0;

        for (int right = 0; right < s.Length; right++) {
            if (map.ContainsKey(s[right]) && map[s[right]] >= left) {
                left = map[s[right]] + 1;
            }

            map[s[right]] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}