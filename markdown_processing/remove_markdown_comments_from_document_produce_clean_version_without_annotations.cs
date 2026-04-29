// Remove all Markdown comments from the document to produce a clean version without annotations.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.md";

            string content = File.ReadAllText(inputPath);
            string cleaned = Regex.Replace(content, @"<!--.*?-->", string.Empty, RegexOptions.Singleline);
            File.WriteAllText(outputPath, cleaned);
            Console.WriteLine("Comments removed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}