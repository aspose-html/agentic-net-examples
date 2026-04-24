// Load HTML from a string with CDN base URI and convert to PNG for CDN assets.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToPngExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><img src=\"image.png\"/></body></html>";
                string baseUri = "https://cdn.example.com/";
                string outputPath = "output.png";

                ImageSaveOptions options = new ImageSaveOptions();

                Converter.ConvertHTML(html, baseUri, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}