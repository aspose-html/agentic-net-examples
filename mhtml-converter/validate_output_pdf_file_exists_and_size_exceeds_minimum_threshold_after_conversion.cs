// Validate that the output PDF file exists and its size exceeds a minimum threshold after conversion.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Initialize PDF save options
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, pdfOptions, outputPath);

            // Verify that the PDF file exists and is not empty
            if (!File.Exists(outputPath))
            {
                throw new Exception($"Output PDF file was not created at path: {outputPath}");
            }

            var fileInfo = new FileInfo(outputPath);
            if (fileInfo.Length == 0)
            {
                throw new Exception("Output PDF file is empty (size 0 bytes).");
            }

            Console.WriteLine($"PDF conversion succeeded. File size: {fileInfo.Length} bytes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}