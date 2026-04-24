// Convert HTML containing external CSS files to PNG while ensuring base URL is set for correct resource loading.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load HTML content from a file
                string htmlContent = System.IO.File.ReadAllText("input.html");

                // Set base URI so external resources (e.g., CSS files) are resolved correctly
                string baseUri = new Uri(System.IO.Path.GetFullPath("input.html")).AbsoluteUri;

                // Configure image saving options (defaults will produce PNG)
                ImageSaveOptions options = new ImageSaveOptions();

                // Define output PNG file path
                string outputPath = "output.png";

                // Perform conversion
                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

                Console.WriteLine("HTML successfully converted to PNG.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}