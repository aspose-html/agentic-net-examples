// Convert EPUB to PNG and simultaneously generate a PDF summary of conversion parameters for documentation purposes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            string epubPath = Path.Combine(dataDir, "sample.epub");
            string pngOutputPath = Path.Combine(dataDir, "output.png");
            string pdfSummaryPath = Path.Combine(dataDir, "summary.pdf");

            // Verify EPUB file exists
            if (!File.Exists(epubPath))
            {
                Console.WriteLine($"EPUB file not found at '{epubPath}'. Please place a valid EPUB file there.");
                return;
            }

            // Convert EPUB to PNG
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions imageOptions = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                imageOptions.HorizontalResolution = 300;
                imageOptions.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, imageOptions, pngOutputPath);
                Console.WriteLine($"EPUB converted to PNG: {pngOutputPath}");
            }

            // Prepare HTML summary of conversion parameters
            string htmlContent = $@"
                <html>
                <head><title>Conversion Summary</title></head>
                <body>
                    <h1>EPUB to PNG Conversion Summary</h1>
                    <ul>
                        <li>Horizontal Resolution: 300 DPI</li>
                        <li>Vertical Resolution: 300 DPI</li>
                        <li>Image Format: PNG</li>
                        <li>Source EPUB: {epubPath}</li>
                        <li>Output PNG: {pngOutputPath}</li>
                    </ul>
                </body>
                </html>";

            // Load HTML document from string
            HTMLDocument summaryDoc = new HTMLDocument(htmlContent, "about:blank");

            // Convert summary HTML to PDF
            PdfSaveOptions pdfOptions = new PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(summaryDoc, pdfOptions, pdfSummaryPath);
            Console.WriteLine($"Conversion summary PDF created: {pdfSummaryPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}