// Convert an HTML file to an XPS document by calling Converter.ConvertHTML with new XpsSaveOptions.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string documentPath = "input.html";
            // Path where the XPS file will be saved
            string savePath = "output.xps";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(documentPath);
            // Create default XPS save options
            XpsSaveOptions options = new XpsSaveOptions();

            // Convert the HTML document to XPS format
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}