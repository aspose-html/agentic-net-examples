// Convert Markdown footnotes to endnotes and adjust references accordingly throughout the document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExample");
            Directory.CreateDirectory(outputDir);

            // Define source markdown file path
            string sourcePath = Path.Combine(outputDir, "document.md");

            // Sample markdown content with footnotes
            string markdownContent = @"This is a sample text with a footnote.[^1]

Another paragraph with a second footnote.[^2]

[^1]: This is the first footnote.
[^2]: This is the second footnote.";

            // Create the markdown file
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Move footnote list to the end of the document (as endnotes)
            var footnoteLists = document.QuerySelectorAll("ol.footnotes");
            foreach (var node in footnoteLists)
            {
                // Ensure the node is an Element before appending
                if (node is Element element)
                {
                    document.Body.AppendChild(element);
                }
            }

            // Save the modified document back to markdown (endnotes)
            string outputPath = Path.Combine(outputDir, "document-endnotes.md");
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}