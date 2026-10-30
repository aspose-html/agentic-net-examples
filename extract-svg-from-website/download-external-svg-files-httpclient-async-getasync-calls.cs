// Download external SVG files using HttpClient with asynchronous GetAsync calls.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            DownloadAndConvertAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task DownloadAndConvertAsync()
    {
        var svgUrls = new List<string>
        {
            "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/acid.svg",
            "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/helloworld.svg"
        };

        using (var httpClient = new HttpClient())
        {
            int i = 0;
            foreach (var url in svgUrls)
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string svgContent = await response.Content.ReadAsStringAsync();

                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                Directory.CreateDirectory(outputDir);
                string outputPath = Path.Combine(outputDir, $"svg_{i}.pdf");

                PdfSaveOptions options = new PdfSaveOptions();

                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, url, options, outputPath);

                Console.WriteLine($"Converted SVG {i} to PDF: {outputPath}");
                i++;
            }
        }
    }
}