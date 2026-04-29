// Implement a feature that automatically deletes source MHTML files after successful conversion to PDF to save space.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MhtmlToPdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source MHTML file and target PDF file paths
            string sourcePath = "sample.mhtml";
            string outputPath = Path.ChangeExtension(sourcePath, ".pdf");

            try
            {
                // Open the MHTML file as a read-only stream
                using (FileStream stream = File.OpenRead(sourcePath))
                {
                    // Create default PDF save options
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Perform the conversion from MHTML to PDF
                    Converter.ConvertMHTML(stream, options, outputPath);
                }

                // Delete the source MHTML file after successful conversion
                File.Delete(sourcePath);
                Console.WriteLine($"Conversion succeeded. PDF saved to '{outputPath}'. Source file deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}