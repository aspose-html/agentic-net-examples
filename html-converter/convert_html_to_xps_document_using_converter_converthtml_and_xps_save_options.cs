// Convert an HTML file to an XPS document by calling Converter.ConvertHTML with new XpsSaveOptions.

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
            string documentPath = "input.html";
            string savePath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<html><body><h1>Hello, XPS!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            // Set XPS save options (default options are sufficient)
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}