// Use a try‑finally block to guarantee disposal of HtmlDocument even when an exception occurs during conversion.

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
                File.WriteAllText(documentPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            HTMLDocument document = null;
            try
            {
                document = new HTMLDocument(documentPath);
                XpsSaveOptions options = new XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                Console.WriteLine("Conversion completed. XPS saved at " + savePath);
            }
            finally
            {
                if (document != null)
                {
                    document.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}