namespace Arrays;

public class PossibleCombinationParenthesis
{
    public List<String> GenerateParenthesis(int n) {
        List<string> list = new List<string>();
        Backtrack(list, "", 0, 0, n);
        return list;
    }
    
    public void Backtrack(List<string> list, string str, int open, int close, int max){
        
        if(str.Length == max*2){
            list.Add(str);
            return;
        }
        
        if(open < max)
            Backtrack(list, str+"(", open+1, close, max);
        if(close < open)
            Backtrack(list, str+")", open, close+1, max);
    }
}