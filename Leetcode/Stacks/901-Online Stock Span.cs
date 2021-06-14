// https://leetcode.com/problems/online-stock-span/
// 901 : Online Stock Span
// Difficulty : Medium
public class StockSpanner {
    private Stack<KeyValuePair<int, int>> stockStack;
    
    public StockSpanner() {
        stockStack = new Stack<KeyValuePair<int, int>>();
    }
    
    public int Next(int price) {
        int span = 1;
        while(stockStack.Count > 0 && stockStack.Peek().Key <= price)
        {
            KeyValuePair<int, int> top = stockStack.Pop();
            span += top.Value;
        }
        
        stockStack.Push(new KeyValuePair<int, int>(price, span));
        return span;
    }
}