// Disable paragraph conversion in MarkdownSaveOptions and verify that paragraphs remain unchanged in the output.

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
            // Sample HTML with two paragraphs
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";

            // Output markdown file path
            string outputPath = "output.md";

            // Configure MarkdownSaveOptions without AutomaticParagraph feature
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link; // Disable AutomaticParagraph

            // Convert HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);

            // Read and display the resulting markdown
            string markdown = File.ReadAllText(outputPath);
            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}