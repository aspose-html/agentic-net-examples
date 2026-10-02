// Verify that automatic paragraph handling correctly converts HTML paragraphs to Markdown using default settings.

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
            // Prepare sample HTML with paragraphs
            string htmlContent = "<p>First paragraph.</p><p>Second paragraph.</p>";
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Define output Markdown file path
            string markdownPath = Path.Combine(Path.GetTempPath(), "sample.md");

            // Configure Markdown save options with automatic paragraph handling
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.AutomaticParagraph;

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read and display the resulting Markdown
            string markdown = File.ReadAllText(markdownPath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}