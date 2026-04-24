// Convert HTML to JPEG and embed a digital signature into the image metadata after conversion.

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
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            // Load the HTML document from the file system
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image saving options for JPEG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Convert the HTML document to a JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Note: Embedding a digital signature into JPEG metadata is not supported directly by Aspose.HTML.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}