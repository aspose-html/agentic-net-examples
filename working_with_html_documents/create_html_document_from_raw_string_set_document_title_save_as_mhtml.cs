// Create an HTML document from a raw string, set document title, and save as MHTML.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample Title</title></head><body><p>Hello, World!</p></body></html>";
            string baseUri = "http://example.com/";
            MHTMLSaveOptions options = new MHTMLSaveOptions();
            string outputPath = "output.mht";

            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}