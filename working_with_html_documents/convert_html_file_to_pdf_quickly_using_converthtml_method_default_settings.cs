// Convert an HTML file to PDF quickly using the ConvertHTML method with default settings.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string inputPath = "input.html";
                // Path where the PDF will be saved
                string outputPath = "output.pdf";

                // Load the HTML document from the file path
                HTMLDocument document = new HTMLDocument(inputPath);

                // Create PDF save options with default settings
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}