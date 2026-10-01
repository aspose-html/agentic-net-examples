// Download external SVG files using HttpClient with asynchronous GetAsync calls.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            HttpClient httpClient = new HttpClient();

            string[] svgUrls = new string[]
            {
                "https://example.com/sample1.svg",
                "https://example.com/sample2.svg"
            };

            for (int i = 0; i < svgUrls.Length; i++)
            {
                HttpResponseMessage response = await httpClient.GetAsync(svgUrls[i]);
                response.EnsureSuccessStatusCode();

                string svgContent = await response.Content.ReadAsStringAsync();
                string baseUri = svgUrls[i];

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"output{i}.pdf");
                PdfSaveOptions options = new PdfSaveOptions();

                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);

                Console.WriteLine($"Saved PDF to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}