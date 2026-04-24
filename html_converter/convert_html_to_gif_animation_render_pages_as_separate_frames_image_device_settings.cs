// Convert HTML to GIF animation by rendering each page to separate frames using ImageDevice settings.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
                throw new ArgumentException("Please provide input HTML file path and output GIF file path.");

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Set image saving options to GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert the HTML document to a GIF image
            Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}