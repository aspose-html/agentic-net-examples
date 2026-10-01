// Selectively convert only heading and list tags from HTML by configuring MarkdownSaveOptions.Features accordingly.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML containing headings and lists
                string htmlContent = "<h1>Sample Title</h1><p>This is a paragraph.</p><ul><li>First item</li><li>Second item</li></ul>";

                // Write HTML to a temporary file
                string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
                File.WriteAllText(htmlPath, htmlContent);

                // Define output Markdown file path
                string markdownPath = Path.Combine(Path.GetTempPath(), "output.md");

                // Configure Markdown save options
                MarkdownSaveOptions options = new MarkdownSaveOptions();
                options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

                // Read and display the resulting Markdown
                string markdown = File.ReadAllText(markdownPath);
                Console.WriteLine("Markdown content:");
                Console.WriteLine(markdown);
                Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}