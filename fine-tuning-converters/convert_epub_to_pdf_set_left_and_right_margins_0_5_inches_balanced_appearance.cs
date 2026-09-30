// Convert an EPUB to PDF and set both left and right margins to 0.5 inches for balanced appearance.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.epub";
            string outputDirectory = "Output";
            string outputPath = Path.Combine(outputDirectory, "result.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a minimal sample EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                // This is a placeholder; in a real scenario, provide a valid EPUB file.
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options with margins of 0.5 inches on left and right
                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromInches(8.27),   // Width (A4)
                        Length.FromInches(11.69)   // Height (A4)
                    ),
                    new Margin(
                        Length.FromInches(0.5),    // Left
                        Length.FromInches(0),      // Top
                        Length.FromInches(0.5),    // Right
                        Length.FromInches(0)       // Bottom
                    )
                );

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}