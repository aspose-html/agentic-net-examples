// Convert an HTML file to an MHTML file with default MHTMLSaveOptions using the static ConvertHTML method.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.mhtml";

            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml);
            }

            HTMLDocument document = new HTMLDocument(sourcePath);
            MHTMLSaveOptions options = new MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}