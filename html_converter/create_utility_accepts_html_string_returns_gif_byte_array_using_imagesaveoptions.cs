// Create a utility that accepts HTML string and returns a GIF byte array using ImageSaveOptions.

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
            string html = "<html><body><h1>Hello, Aspose!</h1></body></html>";
            byte[] gifBytes = ConvertHtmlToGifBytes(html);
            Console.WriteLine($"Generated GIF byte array length: {gifBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertHtmlToGifBytes(string htmlContent)
    {
        // Create image save options for GIF format
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

        // Use a temporary file to store the GIF output
        string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".gif");

        // Convert HTML content to GIF image file
        Converter.ConvertHTML(htmlContent, string.Empty, options, tempFile);

        // Read the generated GIF file into a byte array
        byte[] result = File.ReadAllBytes(tempFile);

        // Clean up the temporary file
        File.Delete(tempFile);

        return result;
    }
}