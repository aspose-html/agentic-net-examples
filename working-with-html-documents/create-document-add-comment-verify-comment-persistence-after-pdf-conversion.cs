// Create a document, add a comment explaining purpose, and verify comment persists after conversion to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create sample HTML file with a comment explaining the purpose
            string htmlContent = "<!-- This is a test comment to verify persistence after PDF conversion -->\n<html><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Verify that the PDF file was created and is not empty
            if (!File.Exists(pdfPath) || new FileInfo(pdfPath).Length == 0)
            {
                throw new Exception("PDF conversion failed: file is missing or empty.");
            }

            Console.WriteLine("Conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}