// Convert 900 pixel height to points and apply it to set paragraph spacing in PDF output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a paragraph
            string htmlContent = "<html><body><p id=\"p1\">This paragraph has spacing set in points.</p></body></html>";

            // Create HTMLDocument from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Calculate points from 900 pixels (assuming 96 DPI: 1px = 0.75pt)
            double points = 900 * 72.0 / 96.0; // 675 points

            // Find the paragraph element and set margin-top and margin-bottom in points
            Aspose.Html.Dom.Element paragraph = document.GetElementById("p1");
            if (paragraph != null)
            {
                string style = $"margin-top:{points}pt; margin-bottom:{points}pt;";
                paragraph.SetAttribute("style", style);
            }

            // Prepare PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Optional: set page size and margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842), // A4 size in points
                new Aspose.Html.Drawing.Margin(72, 72, 72, 72) // 1 inch margins
            );
            options.PageSetup.AnyPage = page;

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}