// Convert an HTML file to a DOCX document using default DocSaveOptions via the one‑line Converter method.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "result.docx";

            HTMLDocument document = new HTMLDocument(inputPath);
            DocSaveOptions options = new DocSaveOptions();

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}