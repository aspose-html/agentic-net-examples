// Use ConvertHTML with ImageRenderingOptions to produce JPG files from a list of remote HTML URLs.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com",
                "https://www.wikipedia.org"
            };

            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputFolder);

            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];
                string outputPath = Path.Combine(outputFolder, $"page{i + 1}.jpg");

                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                // Optional: set resolution or quality if needed
                // options.HorizontalResolution = 300;
                // options.VerticalResolution = 300;
                // options.JpegQuality = 90;

                // Convert the remote HTML page to JPEG
                Aspose.Html.Converters.Converter.ConvertHTML(string.Empty, url, options, outputPath);

                Console.WriteLine($"Converted '{url}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}