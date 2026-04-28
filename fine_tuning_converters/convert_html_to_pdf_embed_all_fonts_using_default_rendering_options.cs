// Convert HTML to PDF and embed all fonts automatically by relying on default PdfRenderingOptions behavior.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the PDF will be saved
            string outputPath = "output.pdf";

            // Load the HTML document from the file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Default PDF save options (fonts are embedded automatically)
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert the HTML document to PDF
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}