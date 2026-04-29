// Ensure the Markdown file ends with a single newline character to satisfy parser requirements.

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
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the Markdown output will be saved
            string savePath = "output.md";

            // Default options for Markdown conversion
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert HTML file to Markdown
            Converter.ConvertHTML(htmlPath, options, savePath);

            // Ensure the Markdown file ends with a single newline character
            string markdown = File.ReadAllText(savePath);
            markdown = markdown.TrimEnd('\r', '\n') + Environment.NewLine;
            File.WriteAllText(savePath, markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}