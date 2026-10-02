// Perform asynchronous HTML to XPS conversion with async Task methods to avoid blocking the main thread.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.xps";

            if (!File.Exists(documentPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(documentPath, sampleHtml);
            }

            await ConvertHtmlToXpsAsync(documentPath, savePath);
            Console.WriteLine("Conversion completed successfully. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static async Task ConvertHtmlToXpsAsync(string documentPath, string savePath)
    {
        await Task.Run(() =>
        {
            HTMLDocument document = new HTMLDocument(documentPath);
            XpsSaveOptions options = new XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        });
    }
}