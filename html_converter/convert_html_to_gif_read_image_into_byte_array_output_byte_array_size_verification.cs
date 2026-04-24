// Convert HTML to GIF, read the generated image into a byte array, and output the byte array size for verification.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtml = "input.html";
            string outputGif = "output.gif";

            HTMLDocument document = new HTMLDocument(inputHtml);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputGif);

            byte[] imageBytes = File.ReadAllBytes(outputGif);
            Console.WriteLine($"Byte array size: {imageBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}