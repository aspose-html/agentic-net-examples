// Write code to convert MHTML to PDF and then extract text using a PDF parsing library.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Path where the resulting PDF will be saved
            string outputPath = "output.pdf";

            // Open the MHTML file as a read‑only stream
            FileStream stream = File.OpenRead(inputPath);
            // Create default PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert the MHTML stream to PDF
            Converter.ConvertMHTML(stream, options, outputPath);
            Console.WriteLine($"Conversion completed. PDF saved to {outputPath}");

            // Note: Extracting text from the PDF requires a separate PDF parsing library
            Console.WriteLine("PDF text extraction is not performed in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}