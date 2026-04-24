// Set ImageSaveOptions.CompressionLevel to optimize GIF file size without sacrificing visual quality significantly.

using System;
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
            string inputPath = "input.html";
            string outputPath = "output.gif";

            HTMLDocument document = new HTMLDocument(inputPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // CompressionLevel is not available for GIF in Aspose.HTML, so default settings are used.

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}