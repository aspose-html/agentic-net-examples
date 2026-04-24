// Convert an HTML document containing a canvas element to JPEG using ImageSaveOptions.

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
            // Path to the source HTML file that contains a <canvas> element
            string inputPath = "input.html";

            // Desired output JPEG file path
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