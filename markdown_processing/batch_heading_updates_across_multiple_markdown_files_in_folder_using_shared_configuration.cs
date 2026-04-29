// Perform batch heading updates across multiple Markdown files in a folder using a shared configuration.

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
            string inputFolder = @"C:\Markdown\Input";
            string outputFolder = @"C:\Markdown\Output";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Shared markdown save options
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                // Convert markdown file to HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(mdPath);

                // Update all heading elements (h1-h6)
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement element = (HTMLElement)headings[i];
                    // Example update: prepend "Updated: " to each heading text
                    element.TextContent = "Updated: " + element.TextContent.Trim();
                }

                // Prepare output markdown path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".md");

                // Convert the modified HTMLDocument back to markdown using shared options
                Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}