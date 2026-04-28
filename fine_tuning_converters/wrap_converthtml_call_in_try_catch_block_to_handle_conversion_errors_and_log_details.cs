// Wrap each ConvertHTML call in a try‑catch block to handle conversion errors and log details.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
        string baseUri = "http://example.com";
        string outputPath = "output.mht";

        try
        {
            MHTMLSaveOptions options = new MHTMLSaveOptions();
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}