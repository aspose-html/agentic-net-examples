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
            string sourcePath;
            string outputPath;

            if (args.Length >= 2)
            {
                sourcePath = args[0];
                outputPath = args[1];
            }
            else
            {
                sourcePath = Path.Combine(Path.GetTempPath(), "sample.md");
                outputPath = Path.Combine(Path.GetTempPath(), "output.html");

                if (!File.Exists(sourcePath))
                {
                    File.WriteAllText(sourcePath, "# Sample Markdown\r\nThis is a *test*.");
                }
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);
            Console.WriteLine($"Converted '{sourcePath}' to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}