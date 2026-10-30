// Convert an EPUB document to PDF while preserving embedded fonts through default rendering behavior.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output PDF path
            string inputFile = "sample.epub";
            string outputDirectory = "output";
            string outputFile = Path.Combine(outputDirectory, "output.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a minimal sample EPUB file if it does not exist
            if (!File.Exists(inputFile))
            {
                // Simple placeholder content; real EPUB should be a valid zip package
                File.WriteAllBytes(inputFile, new byte[] { 0x50, 0x4B, 0x03, 0x04 });
            }

            // Open read stream for the EPUB file
            using (Stream stream = File.OpenRead(inputFile))
            {
                // Convert EPUB to PDF preserving embedded fonts (default behavior)
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, new PdfSaveOptions(), outputFile);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}