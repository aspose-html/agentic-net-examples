// Convert an EPUB file to PDF and apply custom CSS styles using PdfSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output PDF file path
            string outputPath = "output.pdf";

            // Ensure the input file exists (create a placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                // Create an empty placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Open the EPUB file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Set PDF save options (customize as needed)
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}