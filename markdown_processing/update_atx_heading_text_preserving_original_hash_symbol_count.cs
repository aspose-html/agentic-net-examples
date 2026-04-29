// Update the text of an ATX heading while preserving its original number of hash symbols.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.md";
            string newHeadingText = "Updated Heading Text";

            string[] lines = File.ReadAllLines(inputPath);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.StartsWith("#"))
                {
                    int hashCount = 0;
                    while (hashCount < line.Length && line[hashCount] == '#')
                        hashCount++;

                    string trimmed = line.Substring(hashCount).TrimStart();
                    int firstSpace = trimmed.IndexOf(' ');
                    string rest = firstSpace >= 0 ? trimmed.Substring(firstSpace + 1) : "";
                    lines[i] = new string('#', hashCount) + " " + newHeadingText;
                    break;
                }
            }

            File.WriteAllLines(outputPath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}