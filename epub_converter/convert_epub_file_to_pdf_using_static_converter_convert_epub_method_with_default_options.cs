// Convert an EPUB file to PDF using the static Converter.ConvertEPUB method with default options.

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
            // Path to the source EPUB file
            string inputPath = "sample.epub";

            // Desired output PDF file path
            string outputPath = "sample.pdf";

            // Open the EPUB file as a readable stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Convert the EPUB stream to PDF using default options
                Converter.ConvertEPUB(stream, new PdfSaveOptions(), outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during conversion
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}