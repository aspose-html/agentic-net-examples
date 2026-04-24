// Apply CSS media type “screen” in ImageSaveOptions before converting HTML to GIF for web‑optimized output.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;

namespace HtmlToGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string inputPath = "input.html";

                // Path where the output GIF will be saved
                string outputPath = "output.gif";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Create image save options with GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Apply CSS media type "screen" for web‑optimized rendering
                options.Css.MediaType = MediaType.Screen;

                // Convert the HTML document to a GIF image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}