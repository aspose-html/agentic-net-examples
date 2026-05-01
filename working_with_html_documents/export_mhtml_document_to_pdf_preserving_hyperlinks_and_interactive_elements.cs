// Export an MHTML document to PDF while preserving hyperlinks and interactive elements.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MhtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input MHTML file and output PDF file paths
            string sourcePath = "input.mhtml";
            string outputPath = "output.pdf";

            try
            {
                // Open the MHTML file as a readable stream
                using (FileStream stream = File.OpenRead(sourcePath))
                {
                    // Create PDF save options with default settings
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();

                    // Convert the MHTML stream to PDF while preserving hyperlinks and interactive elements
                    Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }

                Console.WriteLine("MHTML has been successfully converted to PDF.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during conversion: {ex.Message}");
            }
        }
    }
}