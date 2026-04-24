// Add error handling to catch Converter.ConvertHTML exceptions and log conversion failures for diagnostics.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            // Base URI for the HTML content (empty if not needed)
            string baseUri = "";
            // Path where the MHTML file will be saved
            string outputPath = "output.mhtml";
            // Options for MHTML saving
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Perform the conversion
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            // Log conversion failure details
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}