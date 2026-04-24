// Convert HTML to TIFF format using Converter.ConvertHTML and save the output file to the local file system.

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
            string htmlPath = "input.html";

            // Desired output TIFF file path
            string tiffPath = "output.tiff";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure image save options for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Perform the conversion and save the TIFF image
            Converter.ConvertHTML(document, options, tiffPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}