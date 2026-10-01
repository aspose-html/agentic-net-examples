// Load HTML from a string with CDN base URI and convert to PNG for CDN assets.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>CDN Example</title></head><body><h1>Hello from CDN</h1><img src=\"images/logo.png\" alt=\"Logo\" /></body></html>";
            string baseUri = "https://cdn.example.com/";
            ImageSaveOptions saveOptions = new ImageSaveOptions(ImageFormat.Png);
            string outputPath = "output.png";

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, saveOptions, outputPath);
            Console.WriteLine($"HTML has been converted to PNG and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}