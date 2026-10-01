// Detect and remove stray backticks that do not form valid code spans to clean markup.

using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string input = "Here is some `code` and a stray backtick ` in the text.";
            string cleaned = RemoveUnmatchedBackticks(input);
            Console.WriteLine("Original: " + input);
            Console.WriteLine("Cleaned: " + cleaned);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string RemoveUnmatchedBackticks(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        // Collect positions of all backticks
        List<int> backtickPositions = new List<int>();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '`')
                backtickPositions.Add(i);
        }

        // Determine which backticks are stray (unmatched)
        HashSet<int> indicesToRemove = new HashSet<int>();
        if (backtickPositions.Count % 2 == 1)
        {
            // Odd number of backticks – the last one is stray
            indicesToRemove.Add(backtickPositions[backtickPositions.Count - 1]);
        }

        // Build the cleaned string without stray backticks
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (!indicesToRemove.Contains(i))
                sb.Append(text[i]);
        }

        return sb.ToString();
    }
}