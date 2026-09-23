// Convert an EPUB file to PDF specifying the output path using Path.Combine for platform‑independent paths.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (sample file)
            string inputPath = "sample.epub";

            // Create a minimal sample EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                // Write an empty file as placeholder (real EPUB content is not required for the example)
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Output directory and file path
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "result.pdf");

            // Open the EPUB file stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Set PDF save options
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}