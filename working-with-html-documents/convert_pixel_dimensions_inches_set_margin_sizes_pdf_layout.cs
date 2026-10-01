// Convert pixel dimensions to inches and use the values to set margin sizes in a PDF layout.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(htmlFilePath))
            {
                File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(htmlFilePath);

            // Define margin in pixels
            double leftPixels = 72;   // 0.75 inch
            double topPixels = 72;
            double rightPixels = 72;
            double bottomPixels = 72;

            // Convert pixels to inches
            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            // Create margin object
            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),
                Aspose.Html.Drawing.Length.FromInches(rightInches),
                Aspose.Html.Drawing.Length.FromInches(bottomInches),
                Aspose.Html.Drawing.Length.FromInches(leftInches));

            // Rendering options for PDF
            var renderOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            // Render to PDF using PdfDevice
            string renderOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_render.pdf");
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(renderOptions, renderOutputPath))
            {
                document.RenderTo(device);
            }

            // Save options for PDF conversion
            var saveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            saveOptions.HorizontalResolution = 300;
            saveOptions.VerticalResolution = 300;
            saveOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            saveOptions.JpegQuality = 90;

            // Convert HTML to PDF using Converter
            string saveOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_save.pdf");
            Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, saveOutputPath);

            Console.WriteLine("PDF files generated successfully:");
            Console.WriteLine(renderOutputPath);
            Console.WriteLine(saveOutputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}