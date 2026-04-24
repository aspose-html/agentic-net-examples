// Load an HTML file with external JavaScript and ensure scripts execute during PDF rendering using default options.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            // Load the HTML document (scripts will be executed by default)
            HTMLDocument document = new HTMLDocument(inputPath);

            // Initialize default PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}