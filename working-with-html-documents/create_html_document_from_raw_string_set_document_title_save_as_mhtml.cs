// Create an HTML document from a raw string, set document title, and save as MHTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            // Base URI required for relative resources (can be a dummy folder)
            string baseUri = Path.GetFullPath(Directory.GetCurrentDirectory()) + Path.DirectorySeparatorChar;
            // Output MHTML file path
            string outputPath = "output.mhtml";

            // Create MHTML save options
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

            // Convert HTML string to MHTML file
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"MHTML file saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}