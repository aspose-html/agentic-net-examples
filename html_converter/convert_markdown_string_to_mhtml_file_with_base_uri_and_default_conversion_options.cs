// Convert a Markdown string to MHTML file by providing base URI and default conversion options.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content (could be generated from a Markdown string)
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            // Base URI used for resolving relative resources in the HTML
            string baseUri = "http://example.com/";
            // Path where the resulting MHTML file will be saved
            string outputPath = "output.mht";

            // Default options for MHTML conversion
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Perform the conversion from HTML string to MHTML file
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion to MHTML completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}