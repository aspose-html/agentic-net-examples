// Render an EPUB to DOCX while setting DocRenderingOptions.PageSize to custom 8.5 by 13 inches.

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
            // Define input EPUB and output DOCX paths
            string dataDir = @"C:\Data";
            string outputDir = @"C:\Output";
            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "sample.docx");

            // Open the EPUB file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create conversion options for DOCX
                DocSaveOptions options = new DocSaveOptions();

                // Set custom page size: 8.5 inches width by 13 inches height
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromInches(8.5),
                        Length.FromInches(13)));

                // Perform the conversion from EPUB to DOCX
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}