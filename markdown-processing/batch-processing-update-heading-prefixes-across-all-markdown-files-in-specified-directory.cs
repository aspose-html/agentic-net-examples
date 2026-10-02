// Perform batch processing to update heading prefixes across all Markdown files in a specified directory.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputMarkdown";
            string outputFolder = @"C:\OutputMarkdown";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                string[] lines = File.ReadAllLines(mdPath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string trimmed = lines[i].TrimStart();
                    if (trimmed.StartsWith("#"))
                    {
                        int level = trimmed.TakeWhile(c => c == '#').Count();
                        string rest = trimmed.Substring(level).TrimStart();
                        string newLine = new string('#', level) + " Updated " + rest;
                        // Preserve original leading whitespace
                        int leadingSpaces = lines[i].Length - trimmed.Length;
                        lines[i] = new string(' ', leadingSpaces) + newLine;
                    }
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileName(mdPath));
                File.WriteAllLines(outputPath, lines);
                Console.WriteLine($"Processed: {Path.GetFileName(mdPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}