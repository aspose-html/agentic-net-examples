// Use the static Converter.ConvertHTML method in a real‑time .NET application to process HTML strings on demand.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace RealTimeHtmlProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML content to be processed
                string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                // Base URI for resolving relative resources
                string baseUri = "http://example.com/";
                // Path where the resulting MHTML file will be saved
                string outputPath = "output.mhtml";

                // Options for MHTML conversion (default settings)
                MHTMLSaveOptions options = new MHTMLSaveOptions();

                // Perform the conversion from HTML string to MHTML file
                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
    }
}