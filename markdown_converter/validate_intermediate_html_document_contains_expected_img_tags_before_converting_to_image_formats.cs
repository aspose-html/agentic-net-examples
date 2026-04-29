// Validate that the intermediate HTMLDocument contains expected <img> tags before converting to image formats.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace ValidateAndConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";
                // Path where the output image will be saved
                string outputPath = "output.jpg";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Validate that the document contains <img> tags
                var imgElements = document.GetElementsByTagName("img");
                if (imgElements.Length == 0)
                {
                    Console.WriteLine("No <img> tags found in the document.");
                    return;
                }
                Console.WriteLine($"Found {imgElements.Length} <img> tag(s) in the document.");

                // Prepare image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Convert the HTML document to an image
                Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("HTML document successfully converted to image.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}