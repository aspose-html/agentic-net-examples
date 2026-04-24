// Convert EPUB to PNG and simultaneously generate a PDF summary of conversion parameters for documentation purposes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file
            string epubPath = Path.Combine("Data", "sample.epub");
            // Output PNG image
            string pngPath = Path.Combine("Output", "sample.png");
            // Output PDF summary
            string pdfPath = Path.Combine("Output", "ConversionSummary.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Convert EPUB to PNG
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions imgOptions = new ImageSaveOptions();
                Converter.ConvertEPUB(epubStream, imgOptions, pngPath);
            }

            // Prepare HTML content for PDF summary
            string htmlContent = $@"
                <html>
                <head><title>Conversion Summary</title></head>
                <body>
                    <h1>EPUB to PNG Conversion Summary</h1>
                    <p><strong>Source EPUB:</strong> {epubPath}</p>
                    <p><strong>Generated PNG:</strong> {pngPath}</p>
                    <p><strong>ImageSaveOptions:</strong> Default settings</p>
                </body>
                </html>";

            // Load HTML into a document
            HTMLDocument doc = new HTMLDocument(htmlContent, "file:///");
            // Convert HTML summary to PDF
            PdfSaveOptions pdfOptions = new PdfSaveOptions();
            Converter.ConvertHTML(doc, pdfOptions, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}