// Convert an EPUB file to PDF specifying the output path using Path.Combine for platform‑independent paths.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace EpubToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output directories
                string inputDir = "input";
                string outputDir = "output";

                // Build full paths using Path.Combine for platform independence
                string sourcePath = Path.Combine(inputDir, "sample.epub");
                string outputPath = Path.Combine(outputDir, "sample.pdf");

                // Create default PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert the EPUB file to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
    }
}