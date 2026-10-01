// Convert 900 pixel height to points and apply it to set paragraph spacing in PDF output.

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
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Configure PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Define page size and margins
            var page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842), // A4 size in points
                new Aspose.Html.Drawing.Margin(20, 20, 20, 20) // left, top, right, bottom
            );

            // Apply page setup
            options.PageSetup.AnyPage = page;

            // Output PDF file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}