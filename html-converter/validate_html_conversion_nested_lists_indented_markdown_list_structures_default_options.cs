// Validate that converting HTML with nested lists produces correctly indented Markdown list structures using default options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string markdownPath = "output.md";

            // Create sample HTML with nested lists
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<ul>" +
                                 "<li>Item 1</li>" +
                                 "<li>Item 2<ul><li>Subitem 1</li><li>Subitem 2</li></ul></li>" +
                                 "<li>Item 3</li>" +
                                 "</ul>" +
                                 "</body></html>";

            // Write HTML content to file
            File.WriteAllText(htmlPath, htmlContent);

            // Set up Markdown save options (default)
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read the generated Markdown
            string markdown = File.ReadAllText(markdownPath);

            // Simple validation of indentation for nested list
            bool hasTopLevelItem = markdown.Contains("- Item 1") && markdown.Contains("- Item 2") && markdown.Contains("- Item 3");
            bool hasNestedItem = markdown.Contains("  - Subitem 1") && markdown.Contains("  - Subitem 2");

            if (hasTopLevelItem && hasNestedItem)
            {
                Console.WriteLine("Validation passed: Nested lists are correctly indented in Markdown.");
            }
            else
            {
                Console.WriteLine("Validation failed: Markdown indentation does not match expected structure.");
                Console.WriteLine("Generated Markdown:");
                Console.WriteLine(markdown);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}