// Convert HTML to PNG and generate the image output without applying external image processing filters.

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
                string html = "<html><body><h1>Hello World</h1></body></html>";
                string baseUri = "";
                string outputPath = "output.png";

                ImageSaveOptions options = new ImageSaveOptions();

                Converter.ConvertHTML(html, baseUri, options, outputPath);
                Console.WriteLine("HTML converted to PNG successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}