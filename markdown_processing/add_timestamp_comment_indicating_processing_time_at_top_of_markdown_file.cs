// Add a timestamp comment indicating processing time at the top of the Markdown file.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.md";
            MarkdownSaveOptions options = MarkdownSaveOptions.Git;
            Converter.ConvertHTML(sourcePath, options, outputPath);
            string markdown = File.ReadAllText(outputPath);
            string timestamp = $"<!-- Processed on {DateTime.Now:O} -->{Environment.NewLine}";
            File.WriteAllText(outputPath, timestamp + markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}