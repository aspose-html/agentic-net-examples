// Perform asynchronous HTML to XPS conversion with async Task methods to avoid blocking the main thread.

using System;
using System.IO;
using System.Threading.Tasks;

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
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(documentPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            await Task.Run(() => Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath));

            Console.WriteLine($"Conversion completed. XPS saved to: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}