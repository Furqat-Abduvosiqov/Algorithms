namespace LeetCode;

public class FindMatchingParentheses
{
    public bool IsValid(string s) {
        
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    stack.Push(')');
                    break;
                case '{':
                    stack.Push('}');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                default:
                {
                    // If no matching opening bracket or wrong type — invalid
                    if (stack.Count == 0 || stack.Pop() != c) return false;
                    break;
                }
            }
        }

        // Stack must be empty if all brackets matched correctly
        return stack.Count == 0;
    }
}