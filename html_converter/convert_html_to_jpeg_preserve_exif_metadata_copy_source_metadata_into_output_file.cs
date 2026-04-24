// Convert HTML to JPEG and preserve EXIF metadata by copying source metadata into the output file.

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
            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);
            // Configure image saving options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Convert the HTML document to a JPEG image
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}