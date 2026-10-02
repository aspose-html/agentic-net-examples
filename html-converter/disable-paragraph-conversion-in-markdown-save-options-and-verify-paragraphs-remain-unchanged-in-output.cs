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
            // Sample HTML with paragraphs
            string htmlContent = "<p>This is a paragraph.</p><p>Another paragraph.</p>";
            string baseUri = "about:blank";

            // Create temporary file for Markdown output
            string markdownPath = Path.GetTempFileName();

            // Configure MarkdownSaveOptions without AutomaticParagraph feature
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link; // Paragraph conversion disabled

            // Convert HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, markdownPath);

            // Read and display the resulting Markdown
            string markdown = File.ReadAllText(markdownPath);
            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);

            // Clean up temporary file
            File.Delete(markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}