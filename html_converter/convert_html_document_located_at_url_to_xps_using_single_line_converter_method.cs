// Convert an HTML document located at a URL to XPS format using a single‑line Converter method.

using System;
using System.Net.Http;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/page.html";
            string outputPath = "output.xps";

            HttpClient client = new HttpClient();
            string htmlContent = client.GetStringAsync(url).Result;

            XpsSaveOptions options = new XpsSaveOptions();
            Converter.ConvertHTML(htmlContent, url, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}