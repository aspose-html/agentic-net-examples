// Convert an HTML file to a GIF image using default conversion and store the output in a folder.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string sourceHtmlPath = "input.html";

            // Folder where the GIF will be saved
            string outputFolder = "output";

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Construct the full output path for the GIF file
            string outputGifPath = Path.Combine(outputFolder,
                Path.GetFileNameWithoutExtension(sourceHtmlPath) + ".gif");

            // Load the HTML document from the file
            HTMLDocument document = new HTMLDocument(sourceHtmlPath);

            // Configure image saving options to use GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Perform the conversion from HTML to GIF
            Converter.ConvertHTML(document, options, outputGifPath);

            Console.WriteLine("HTML successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}