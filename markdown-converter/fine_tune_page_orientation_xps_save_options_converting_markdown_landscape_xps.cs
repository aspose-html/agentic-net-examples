// Fine‑tune the page orientation in XpsSaveOptions when converting Markdown to landscape XPS.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdownContent = "# Sample Title\n\nThis is a **markdown** document.";

            // Wrap markdown in simple HTML (for demonstration)
            string htmlContent = $"<html><body>{markdownContent}</body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Configure XPS save options for landscape orientation
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            // Landscape page size: 11 inches width x 8.5 inches height, zero margins
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8.5)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed successfully. XPS saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}