/*
 Implement this function in C# that determines if a text has correctly balanced parentheses, 
brackets, and braces. That is, for every opening symbol there must be a corresponding closing symbol, 
and the nesting order must be correct.

static bool ItsBalanced(string texto)
{
    // Your code
}

Examples of balanced texts
()
(a[b{c}d]e)
int main() { return 0; }
Examples of unbalanced texts
({[}])
func(a, b[0}
*/

class Program
{
    static void Main()
    {
        string[] examples = {
            "((()))",
            "(a[b{c}d]e)",
            "int main() { return 0; }",
            "({[}])",
            "func(a, b[0}"
        };

        foreach (var text in examples)
        {
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"It's balanced?: {ItsBalanced(text)}");
            Console.WriteLine(new string('-', 20));
        }
    }

    static bool ItsBalanced(string text)
    {
        var stack = new Stack<char>();
        var pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (var c in text)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

}
