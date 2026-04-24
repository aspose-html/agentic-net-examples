// Use try‑catch block around Converter.ConvertHTML to capture conversion errors and log exception details.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        string documentPath = "input.html";
        string savePath = "output.xps";

        HTMLDocument document = new HTMLDocument(documentPath);
        XpsSaveOptions options = new XpsSaveOptions();

        try
        {
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}