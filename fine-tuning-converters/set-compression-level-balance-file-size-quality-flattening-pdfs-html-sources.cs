// Set PdfSaveOptions.CompressionLevel to balance file size and quality when flattening PDFs from HTML sources.

using System;
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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, PDF!</h1><p>This PDF is generated from HTML.</p></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Note: PdfSaveOptions does not expose a CompressionLevel property in the current API.
            // Image quality inside the PDF can be influenced via rendering options if needed.

            // Convert HTML to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}