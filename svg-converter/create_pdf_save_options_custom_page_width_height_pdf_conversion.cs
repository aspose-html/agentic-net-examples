// Create PdfSaveOptions with custom page width and height for PDF conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Set custom page size and margins
            var pageSize = new Aspose.Html.Drawing.Size(595, 842); // Approximate A4 size in points
            var margin = new Aspose.Html.Drawing.Margin(50, 50, 50, 50);
            var page = new Aspose.Html.Drawing.Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            // Output PDF path
            string outputPath = "output.pdf";

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}