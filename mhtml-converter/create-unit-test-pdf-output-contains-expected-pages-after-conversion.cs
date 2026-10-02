// Create a unit test that ensures the PDF output contains the expected number of pages after conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Test Page</h1><p>This is a test.</p></body></html>");
            }

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            // Verify that the PDF file was created and is not empty
            if (!File.Exists(outputPath))
                throw new Exception("PDF file was not created.");

            FileInfo pdfInfo = new FileInfo(outputPath);
            if (pdfInfo.Length == 0)
                throw new Exception("PDF file is empty.");

            Console.WriteLine("Conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}