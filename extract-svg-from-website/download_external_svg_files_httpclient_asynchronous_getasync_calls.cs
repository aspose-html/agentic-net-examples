// Download external SVG files using HttpClient with asynchronous GetAsync calls.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            string[] svgUrls = new string[]
            {
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/acid.svg",
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/helloworld.svg"
            };

            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < svgUrls.Length; i++)
                {
                    string url = svgUrls[i];
                    string svgContent = client.GetStringAsync(url).GetAwaiter().GetResult();
                    string baseUri = url;
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"output_{i}.pdf");

                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);
                }
            }

            Console.WriteLine("SVG files downloaded and converted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}