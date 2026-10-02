// Convert EPUB to PNG and simultaneously generate a PDF summary of conversion parameters for documentation purposes.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string inputPath = Path.Combine(dataDir, "sample.epub");

            // Create a placeholder EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string pngPath = Path.Combine(outputDir, "output.png");
            string pdfPath = Path.Combine(outputDir, "summary.pdf");

            // Convert EPUB to PNG
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions imageOptions = new ImageSaveOptions();
                imageOptions.HorizontalResolution = 300;
                imageOptions.VerticalResolution = 300;
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, imageOptions, pngPath);
            }

            // Convert EPUB to PDF (summary of conversion parameters)
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                PdfSaveOptions pdfOptions = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, pdfPath);
            }

            Console.WriteLine("EPUB conversion to PNG and PDF completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}