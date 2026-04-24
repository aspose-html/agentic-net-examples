// Convert HTML strings directly to GIF images using static conversion method and specifying output path.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlToGifExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // HTML content to be converted
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";

                // Output GIF file path
                string outputPath = "result.gif";

                // Load HTML content into an HTMLDocument
                HTMLDocument document = new HTMLDocument(htmlContent);

                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Perform conversion from HTMLDocument to GIF image
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}