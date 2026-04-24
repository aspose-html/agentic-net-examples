// Generate a thumbnail PNG from HTML by setting reduced page dimensions in ImageSaveOptions before conversion.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Path where the thumbnail PNG will be saved
            string outputPath = "thumbnail.png";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create image save options for PNG conversion
            ImageSaveOptions options = new ImageSaveOptions();

            // Set reduced page dimensions for the thumbnail (e.g., 100x100 pixels)
            options.PageSetup.AnyPage = new Page(new Size(100, 100));

            // Convert the HTML document to a PNG image using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}