// https://leetcode.com/problems/sorting-the-sentence/
// 1859 : Sorting the Sentence
// Difficulty : Easy
public class Solution {
    public string SortSentence(string s) {
        List<string> words = new List<string>();
        int maxIndex = 0;
        int wordStart = 0;
        for (int index = 0; index < s.Length; index++)
        {
            if (s[index] == ' ')
            {
                wordStart = index + 1;
                continue;
            }

            int charValue = s[index] - '0';
            if (charValue > 0 && charValue <= 9)
            {
                if (charValue > maxIndex)
                {
                    for (int i = maxIndex; i < charValue; i++)
                        words.Add(null);
                    maxIndex = charValue;
                }
                words[charValue - 1] = s.Substring(wordStart, index - wordStart);
            }
        }

        return String.Join(' ', words);
    }
}