// Convert an HTML file to a TIFF image using default settings and saving to a specified output file.

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

            // Load the HTML document from the file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create image save options with TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Convert the HTML document to a TIFF image
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}