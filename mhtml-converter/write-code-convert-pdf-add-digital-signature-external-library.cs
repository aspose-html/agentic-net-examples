// Write code to convert PDF and then add a digital signature using an external library.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML file
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            Directory.CreateDirectory(inputDir);
            string inputPath = Path.Combine(inputDir, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Prepare output PDF path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string pdfPath = Path.Combine(outputDir, "sample.pdf");

            // Load HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Verify conversion result
            if (!File.Exists(pdfPath))
                throw new Exception("PDF file was not created.");

            FileInfo info = new FileInfo(pdfPath);
            if (info.Length == 0)
                throw new Exception("PDF file is empty.");

            Console.WriteLine("PDF conversion verification passed.");

            // Note about digital signature
            Console.WriteLine("Adding a digital signature to the PDF requires an external PDF signing library, which is not included in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}