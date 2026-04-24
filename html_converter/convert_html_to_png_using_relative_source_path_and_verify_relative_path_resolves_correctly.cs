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
            // Relative path to the source HTML file
            string documentPath = "relative/path/to/input.html";

            // Path where the PNG image will be saved
            string outputPath = "output.png";

            // Load the HTML document using the relative path
            HTMLDocument document = new HTMLDocument(documentPath);

            // Configure image save options for PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Convert the HTML document to a PNG image
            Converter.ConvertHTML(document, options, outputPath);

            // Verify that the PNG file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("HTML successfully converted to PNG: " + Path.GetFullPath(outputPath));
            }
            else
            {
                Console.WriteLine("Conversion failed: PNG file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}