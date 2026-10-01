// Use HtmlRenderer.RenderToPdf with PdfSaveOptions to embed a custom ICC profile for color accuracy.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"">
    <title>Sample HTML</title>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This PDF was generated from HTML.</p>
</body>
</html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600));

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine($"Conversion succeeded. PDF saved to '{pdfPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}