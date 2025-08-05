// Find all substring from string

using System.Text;

var text = "abcd";

for (int i = 0; i < text.Length; i++)
{
    StringBuilder substring = new StringBuilder(text.Length - i);

    for (int j = i; j < text.Length; j++)
    {
        substring.Append(text[j]);
        Console.WriteLine(substring);
    }
}

