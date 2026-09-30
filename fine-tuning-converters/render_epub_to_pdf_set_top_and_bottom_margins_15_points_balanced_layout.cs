// Render an EPUB to PDF and set both top and bottom margins to 15 points for balanced layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (replace with actual path if needed)
            string inputPath = "sample.epub";
            // Output PDF file path
            string outputPath = "output.pdf";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open EPUB file stream
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Configure PDF rendering options with margins (15 points top and bottom)
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(595, 842), // A4 size in points
                    new Aspose.Html.Drawing.Margin(0, 15, 0, 15) // left, top, right, bottom margins
                );
                pdfOptions.PageSetup.AnyPage = page;

                // Create PDF device with the specified options and output path
                Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath);

                // Render EPUB to PDF
                Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer();
                renderer.Render(pdfDevice, epubStream);
            }

            Console.WriteLine("EPUB successfully rendered to PDF: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}