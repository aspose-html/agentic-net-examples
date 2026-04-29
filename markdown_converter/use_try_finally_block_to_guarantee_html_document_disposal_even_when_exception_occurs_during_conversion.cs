// Use a try‑finally block to guarantee disposal of HtmlDocument even when an exception occurs during conversion.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input HTML and output XPS files
            string documentPath = "input.html";
            string outputPath = "output.xps";

            // Create the HTML document instance
            HTMLDocument document = new HTMLDocument(documentPath);
            try
            {
                // Initialize default XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion
                Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Ensure the HTMLDocument is disposed even if an exception occurs
                document.Dispose();
            }
        }
    }
}