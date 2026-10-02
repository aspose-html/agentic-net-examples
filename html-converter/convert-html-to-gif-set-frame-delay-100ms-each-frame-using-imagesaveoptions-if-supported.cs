// Convert HTML to GIF and set frame delay to 100ms for each frame using ImageSaveOptions if supported.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set up image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}