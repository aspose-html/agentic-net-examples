// Convert HTML with mixed content using default options to verify comprehensive element handling.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlConversionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file containing mixed content
                string documentPath = "input.html";
                // Path where the resulting XPS file will be saved
                string savePath = "output.xps";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(documentPath);

                // Create default XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Convert HTML to XPS
                Converter.ConvertHTML(document, options, savePath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}