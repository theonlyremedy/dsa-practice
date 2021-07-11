// https://leetcode.com/problems/reorganize-string/
// 767 : Reorganize String
// Difficulty : Medium
public class Solution {
    public string ReorganizeString(string s) {
        if (s.Length <= 1)
            return s;

        int[] chars = new int[26];
        foreach (char c in s)
            chars[c - 'a'] += 1;

        MaxHeap charHeap = new MaxHeap();

        for (int i = 0; i < 26; i++)
        {
            if (chars[i] != 0)
            {
                char c = (char)('a' + i);
                charHeap.InsertItem(c, chars[i]);
            }
        }

        StringBuilder sb = new StringBuilder();
        Item previous = charHeap.Remove();
        for (int i = 0; i < s.Length; i++)
        {
            sb.Append(previous.Character);
            Item next = charHeap.Remove();

            if (next == null && previous.Count > 1)
                return String.Empty;

            if (previous.Count > 1)
                charHeap.InsertItem(previous.Character, --previous.Count);
            previous = next;
        }

        return sb.ToString();
    }
}

public class Item
{
    public char Character { get; set; }
    public int Count { get; set; }

    public Item(char character, int count)
    {
        this.Character = character;
        this.Count = count;
    }
}

public class MaxHeap
{
    List<Item> heapItems;

    public bool IsEmpty
    {
        get { return heapItems.Count == 0; }
    }

    public MaxHeap()
    {
        heapItems = new List<Item>();
    }

    public void InsertItem(char c, int count)
    {
        heapItems.Add(new Item(c, count));
        if (heapItems.Count > 1)
            SiftUp(heapItems.Count - 1);
    }

    public Item Peek()
    {
        if (heapItems.Count == 0)
            return null;
        return heapItems[0];
    }

    public Item Remove()
    {
        if (heapItems.Count == 0)
            return null;
        Item temp = heapItems[heapItems.Count - 1];
        heapItems[heapItems.Count - 1] = heapItems[0];
        heapItems[0] = temp;
        Item lastItem = heapItems[heapItems.Count - 1];
        heapItems.RemoveAt(heapItems.Count - 1);
        SiftDown(0);
        return lastItem;
    }

    public void SiftUp(int index)
    {
        int parentIndex = (index - 1) / 2;
        if (heapItems[parentIndex].Count < heapItems[index].Count)
        {
            Item temp = heapItems[parentIndex];
            heapItems[parentIndex] = heapItems[index];
            heapItems[index] = temp;
            SiftUp(parentIndex);
        }
    }

    public void SiftDown(int index)
    {
        int child1Index = (2 * index) + 1;
        int child2Index = (2 * index) + 2;

        int largestIndex = -1;
        if (child1Index < heapItems.Count)
            largestIndex = child1Index;

        if (child2Index < heapItems.Count && heapItems[child1Index].Count < heapItems[child2Index].Count)
            largestIndex = child2Index;

        if (largestIndex > -1 && heapItems[largestIndex].Count > heapItems[index].Count)
        {
            Item temp = heapItems[index];
            heapItems[index] = heapItems[largestIndex];
            heapItems[largestIndex] = temp;
            SiftDown(largestIndex);
        }
    }
}