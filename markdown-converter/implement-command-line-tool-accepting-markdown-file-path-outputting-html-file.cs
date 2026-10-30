// Implement a command‑line tool that accepts a Markdown file path and outputs an HTML file.

using System;
using System.IO;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.md";
            string outputPath = "output.html";

            if (args.Length >= 1 && !string.IsNullOrWhiteSpace(args[0]))
                inputPath = args[0];
            if (args.Length >= 2 && !string.IsNullOrWhiteSpace(args[1]))
                outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                string sampleContent = "# Sample Markdown\r\n\r\nThis is a *sample* markdown file.";
                File.WriteAllText(inputPath, sampleContent);
                Console.WriteLine($"Created sample markdown file at '{inputPath}'.");
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath, outputPath);
            Console.WriteLine($"Markdown file '{inputPath}' has been converted to HTML at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}