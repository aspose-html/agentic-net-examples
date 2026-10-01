// Convert an HTML file to an XPS document using default options and write the result to a path.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string documentPath = "input.html";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(documentPath))
            {
                System.IO.File.WriteAllText(documentPath, "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine($"HTML converted to XPS successfully: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}