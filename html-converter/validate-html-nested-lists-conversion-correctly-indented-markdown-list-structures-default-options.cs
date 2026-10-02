// Validate that converting HTML with nested lists produces correctly indented Markdown list structures using default options.

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
            string htmlPath = "sample.html";
            string markdownPath = "output.md";

            // Create sample HTML with nested lists
            string htmlContent = "<!DOCTYPE html><html><body><ul><li>Item 1</li><li>Item 2<ul><li>Subitem 1</li><li>Subitem 2</li></ul></li><li>Item 3</li></ul></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Convert HTML to Markdown using default options
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read and display the resulting Markdown
            string markdown = File.ReadAllText(markdownPath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);

            // Simple validation of indentation
            bool isValid = markdown.Contains("- Item 1") && markdown.Contains("  - Subitem 1");
            Console.WriteLine(isValid ? "Validation passed." : "Validation failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}