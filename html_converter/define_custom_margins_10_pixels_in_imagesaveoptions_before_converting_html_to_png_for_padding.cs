// Define custom margins of 10 pixels in ImageSaveOptions before converting HTML to PNG for padding.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Desired output PNG file path
            string outputPath = "output.png";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create image save options and set custom margins (10 pixels on each side)
            ImageSaveOptions options = new ImageSaveOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(800, 600),               // Page size (width x height) in pixels
                new Margin(10, 10, 10, 10)        // Left, Top, Right, Bottom margins
            );

            // Convert HTML to PNG using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}