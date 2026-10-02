// Validate that the output PDF file exists and its size exceeds a minimum threshold after conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define file paths
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose HTML</h1></body></html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Set PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert HTML file to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(inputHtmlPath, options, outputPdfPath);

            // Verify the output PDF file
            if (!File.Exists(outputPdfPath))
            {
                throw new Exception("PDF file was not created.");
            }

            FileInfo pdfInfo = new FileInfo(outputPdfPath);
            if (pdfInfo.Length == 0)
            {
                throw new Exception("PDF file is empty.");
            }

            Console.WriteLine("Conversion verification passed. PDF size: " + pdfInfo.Length + " bytes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}