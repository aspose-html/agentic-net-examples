// Ensure each list is preceded by a blank line to conform with Markdown spacing conventions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define source HTML file and target Markdown file paths
            string htmlPath = "input.html";
            string markdownPath = "output.md";

            // Create default Markdown save options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert HTML file to Markdown
            Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Ensure each list in the generated Markdown is preceded by a blank line
            string[] lines = File.ReadAllLines(markdownPath);
            using (StreamWriter writer = new StreamWriter(markdownPath, false))
            {
                string previousLine = string.Empty;
                foreach (string line in lines)
                {
                    string trimmed = line.TrimStart();
                    bool isList = trimmed.StartsWith("-") ||
                                  trimmed.StartsWith("*") ||
                                  trimmed.StartsWith("+") ||
                                  System.Text.RegularExpressions.Regex.IsMatch(trimmed, @"^\d+\.");

                    if (isList && !string.IsNullOrWhiteSpace(previousLine))
                    {
                        writer.WriteLine();
                    }

                    writer.WriteLine(line);
                    previousLine = line;
                }
            }

            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}