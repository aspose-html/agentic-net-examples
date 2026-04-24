// Convert an HTML file to a JPEG image with default options and write the result to disk.

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
            string sourcePath = "input.html";
            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Configure image save options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Perform the conversion from HTML to JPEG
            Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("HTML successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}