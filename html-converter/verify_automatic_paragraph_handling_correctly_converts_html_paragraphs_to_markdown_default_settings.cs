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
            // Define input and output paths
            string htmlPath = "sample.html";
            string markdownPath = "output.md";

            // Create a minimal HTML file with paragraphs
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure Markdown save options with AutomaticParagraph feature
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.AutomaticParagraph;

            // Perform conversion from HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read and display the generated Markdown
            string markdownResult = File.ReadAllText(markdownPath);
            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdownResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}