// Use ConvertHTML with ImageRenderingOptions to produce JPG files from a list of remote HTML URLs.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static async Task Main()
    {
        try
        {
            // List of remote HTML URLs to convert
            string[] urls = new string[]
            {
                "https://example.com/page1.html",
                "https://example.com/page2.html"
            };

            // Directory where JPEG files will be saved
            string outputFolder = "OutputImages";
            Directory.CreateDirectory(outputFolder);

            using HttpClient client = new HttpClient();
            int index = 0;

            foreach (string url in urls)
            {
                // Download HTML content from the remote URL
                string htmlContent = await client.GetStringAsync(url);

                // Base URI for resolving relative resources in the HTML
                string baseUri = url;

                // Configure image rendering options for JPEG output
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Determine output file path
                string outputPath = Path.Combine(outputFolder, $"page{index}.jpg");

                // Convert HTML to JPEG using Aspose.HTML
                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}