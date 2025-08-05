// Count characters in a string

var text = "This is a string and nothing more than a string";

Dictionary<char, int> characterCount = new Dictionary<char, int>();

foreach (var character in text)
{
    if (character != ' ')
    {
        if (!characterCount.ContainsKey(character))
        {
            characterCount.Add(character, 1);
        }
        else
        {
            characterCount[character]++;
        }
    }
}

foreach (var character in characterCount.OrderBy(x => x.Key))
{
    Console.WriteLine($"{character.Key}: {character.Value}");
}