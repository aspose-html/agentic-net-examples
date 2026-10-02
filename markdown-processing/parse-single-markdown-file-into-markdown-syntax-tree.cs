// Parse a single Markdown file into a MarkdownSyntaxTree using the MarkdownParser class.

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
            File.WriteAllText(markdownPath, "# Hello\nThis is a test markdown file.");

            // Define output HTML file path
            string htmlPath = "sample.html";

            // Convert markdown to HTML using Aspose.Html
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, htmlPath);

            Console.WriteLine("Markdown converted successfully to HTML at: " + htmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}