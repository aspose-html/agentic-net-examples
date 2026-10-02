// Create a reusable method that accepts a Markdown path and target format enum, returning the output file path.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample markdown file
            string markdownPath = "sample.md";
            File.WriteAllText(markdownPath, "# Hello\nThis is a sample markdown.");

            // Convert markdown to HTML
            string outputPath = ConvertMarkdownToHtml(markdownPath);
            Console.WriteLine($"Converted file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ConvertMarkdownToHtml(string markdownPath)
    {
        // Generate HTML file from markdown
        string htmlPath = Path.ChangeExtension(markdownPath, ".html");
        Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, htmlPath);
        return htmlPath;
    }
}