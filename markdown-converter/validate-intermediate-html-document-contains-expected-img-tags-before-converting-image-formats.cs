// Validate that the intermediate HTMLDocument contains expected <img> tags before converting to image formats.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing <img> tags
            string htmlContent = "<html><body><img src='image1.png'/><img src='image2.png'/></body></html>";
            // Create HTMLDocument from inline content
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Validate presence of <img> elements
            var imgCollection = document.GetElementsByTagName("img");
            if (imgCollection == null || imgCollection.Length == 0)
            {
                throw new Exception("The HTML document does not contain any <img> tags.");
            }
            Console.WriteLine("Found <img> tags: " + imgCollection.Length);

            // Convert to JPEG image
            string outputPath = "output.jpg";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}