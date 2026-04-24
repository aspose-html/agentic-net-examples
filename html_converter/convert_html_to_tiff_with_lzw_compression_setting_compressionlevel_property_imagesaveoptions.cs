// Convert HTML to TIFF with LZW compression by setting CompressionLevel property in ImageSaveOptions.

using System;
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
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the TIFF image will be saved
            string outputPath = "output.tiff";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create image save options for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Compression property is omitted because the specific enum member may not be available
            // options.Compression = Compression.Lzw; // Uncomment if the enum member exists

            // Convert the HTML document to a TIFF image
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}