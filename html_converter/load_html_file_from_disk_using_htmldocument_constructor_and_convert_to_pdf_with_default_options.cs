// Load an HTML file from disk using HTMLDocument constructor and convert to PDF with default options.

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
            // Path to the source HTML file on disk
            string inputPath = "input.html";

            // Desired path for the generated PDF file
            string outputPath = "output.pdf";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);

            // Initialize default PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Perform the conversion from HTML to PDF
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}