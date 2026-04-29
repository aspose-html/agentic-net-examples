// Fine‑tune the page orientation in XpsSaveOptions when converting Markdown to landscape XPS.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace MarkdownToLandscapeXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source markdown file
                string inputPath = "input.md";
                // Desired output XPS file path
                string outputPath = "output.xps";

                // Load the markdown file as an HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Create XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Set landscape page orientation (width > height) with zero margins
                options.PageSetup.AnyPage = new Page(
                    new Size(Length.FromInches(11), Length.FromInches(8.5)),
                    new Margin(0, 0, 0, 0));

                // Convert the document to XPS using the specified options
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