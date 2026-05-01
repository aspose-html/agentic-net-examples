// Save the document as PNG using HTMLDocument.Save with ImageSaveOptions specifying PNG format.

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
            // Input HTML file path
            string htmlPath = "input.html";
            // Output PNG file path
            string outputPath = "output.png";

            // Configure image save options for PNG format
            var options = new ImageSaveOptions(ImageFormat.Png);

            // Load the HTML document
            var document = new HTMLDocument(htmlPath);

            // Convert HTML to PNG and save to the specified path
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}