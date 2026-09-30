// Use ConvertHTML with PdfRenderingOptions to generate PDF files from HTML while applying a custom background color.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, PDF!</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure PDF save options with custom background color
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.FromArgb(255, 173, 216, 230); // LightBlue

            // Convert HTML to PDF
            string pdfPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}