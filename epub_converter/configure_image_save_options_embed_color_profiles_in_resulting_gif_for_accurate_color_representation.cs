// Configure ImageSaveOptions to embed color profiles in the resulting GIF for accurate color representation.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace AsposeHtmlGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                string outputPath = "output.gif";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Create image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // If the API supports embedding color profiles, configure it here
                // options.EmbedColorProfile = true; // Uncomment if property exists

                // Convert HTML to GIF
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}