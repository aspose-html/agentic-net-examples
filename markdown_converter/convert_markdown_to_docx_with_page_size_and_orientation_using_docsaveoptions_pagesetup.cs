// Convert Markdown to DOCX while setting page size and orientation via DocSaveOptions PageSetup.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

namespace MarkdownToDocx
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source Markdown file
                string sourcePath = "sample.md";

                // Path where the resulting DOCX will be saved
                string outputPath = "result.docx";

                // Create conversion options and configure page size and margins
                DocSaveOptions options = new DocSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(500, 1000),               // Width = 500 points, Height = 1000 points
                    new Margin(20, 20, 10, 10)          // Top, Right, Bottom, Left margins
                );

                // Convert the Markdown file to an intermediate HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Convert the HTMLDocument to DOCX using the configured options
                Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}