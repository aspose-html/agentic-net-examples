// Validate that the intermediate HTMLDocument contains expected <img> tags before converting to image formats.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with <img> tags
            string htmlContent = "<html><body><h1>Sample</h1><img src='https://example.com/image1.png' alt='Img1'/><img src='https://example.com/image2.jpg' alt='Img2'/></body></html>";
            // Load HTMLDocument from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Validate presence of <img> tags
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            if (images == null || images.Length == 0)
            {
                throw new InvalidOperationException("No <img> tags found in the HTML document.");
            }

            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)images[i];
                Console.WriteLine("Found image src: " + img.Src);
            }

            // Convert to JPEG image
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}