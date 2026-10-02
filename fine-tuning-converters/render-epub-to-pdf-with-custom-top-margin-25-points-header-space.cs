// Render an EPUB to PDF with custom top margin of 25 points to accommodate header space.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output PDF file path
            string outputPath = Path.Combine("output", "result.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open EPUB file stream
            using (FileStream epubStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Configure PDF save options with custom top margin (25 points)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Define page size (A4) and margins (left, top, right, bottom)
                Page page = new Page(
                    new Size(595, 842),                     // Width and height in points
                    new Margin(0, 25, 0, 0)                 // Left, Top, Right, Bottom margins
                );

                pdfOptions.PageSetup.AnyPage = page;

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}