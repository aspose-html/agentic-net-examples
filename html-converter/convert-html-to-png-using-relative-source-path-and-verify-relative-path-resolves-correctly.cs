// Convert HTML to PNG using a relative source path and verify that the relative path resolves correctly.

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
            // Define relative paths
            string htmlFilePath = "sample.html";
            string imageFolder = "images";
            string imageFileName = "pic.png";
            string imageFilePath = Path.Combine(imageFolder, imageFileName);
            string outputFilePath = "output.png";

            // Ensure image folder exists
            Directory.CreateDirectory(imageFolder);

            // Create a minimal PNG image (1x1 pixel)
            string base64Png = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=";
            byte[] pngBytes = Convert.FromBase64String(base64Png);
            File.WriteAllBytes(imageFilePath, pngBytes);

            // Create HTML content that references the relative image
            string htmlContent = $"<html><body><h1>Test Image</h1><img src=\"{imageFolder}/{imageFileName}\" alt=\"Test\"/></body></html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document using the relative path
            HTMLDocument document = new HTMLDocument(htmlFilePath);

            // Set up image save options for PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputFilePath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}