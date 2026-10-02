// Convert an HTML file to an XPS document using default options and write the result to a path.

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
            string documentPath = "sample.html";
            string savePath = "output.xps";

            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, XPS!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}