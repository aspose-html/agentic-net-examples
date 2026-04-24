// Disable paragraph conversion in MarkdownSaveOptions and verify that paragraphs remain unchanged in the output.

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
            // Define file paths
            string htmlPath = "sample.html";
            string markdownPath = "output.md";

            // Create a simple HTML file with a paragraph and a link
            string htmlContent = "<html><body><p>This is a paragraph.</p><a href=\"https://example.com\">Link</a></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Initialize Markdown save options and disable automatic paragraph conversion
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link; // only link conversion enabled

            // Convert HTML to Markdown using the configured options
            Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read the generated Markdown file
            string markdownResult = File.ReadAllText(markdownPath);

            // Verify that paragraph tags remain unchanged (i.e., <p> is present)
            bool paragraphUnchanged = markdownResult.Contains("<p>");

            Console.WriteLine(paragraphUnchanged
                ? "Paragraph conversion disabled: verification passed."
                : "Verification failed: paragraph was converted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}