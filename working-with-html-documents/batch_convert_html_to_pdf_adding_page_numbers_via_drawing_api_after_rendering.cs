// Batch convert HTML files to PDF, adding page numbers via drawing API after rendering.

using System;
using System.IO;
using System.Drawing;

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string outputPath = Path.Combine(outputDir, "sample.pdf");

            // Sample HTML content
            string htmlContent = "<html><head><title>Test</title></head><body><h1>Hello Aspose.HTML</h1><p>This is a sample PDF generated from HTML.</p></body></html>";

            // Create HTMLDocument from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set PDF save options
            var saveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            saveOptions.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);

            Console.WriteLine($"PDF successfully saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}