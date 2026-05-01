// Convert an HTML file to DOCX while preserving layout using ConvertHTML method.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToDocxExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string inputPath = "input.html";
                // Desired path for the output DOCX file
                string outputPath = "output.docx";

                // Load the HTML document from the file system
                HTMLDocument document = new HTMLDocument(inputPath);

                // Create default DOCX save options
                DocSaveOptions options = new DocSaveOptions();

                // Perform the conversion from HTML to DOCX
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}