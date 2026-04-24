// Perform asynchronous HTML to XPS conversion with async Task methods to avoid blocking the main thread.

using System;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToXpsAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string documentPath = "input.html";
                string savePath = "output.xps";
                await ConvertHtmlToXpsAsync(documentPath, savePath);
                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static Task ConvertHtmlToXpsAsync(string documentPath, string savePath)
        {
            return Task.Run(() =>
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            });
        }
    }
}