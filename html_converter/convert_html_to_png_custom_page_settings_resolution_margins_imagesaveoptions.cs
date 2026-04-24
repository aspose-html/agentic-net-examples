// Convert HTML to PNG while applying custom page settings such as resolution and margins using ImageSaveOptions.

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
            string inputPath = "input.html";
            // Desired output PNG file path
            string outputPath = "output.png";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create image save options and configure custom settings
            ImageSaveOptions options = new ImageSaveOptions();
            // Set resolution (dpi)
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            // Define page size and margins
            options.PageSetup.AnyPage = new Page(
                new Size(800, 600),               // Width = 800px, Height = 600px
                new Margin(40, 40, 40, 40)        // Left, Top, Right, Bottom margins
            );

            // Convert HTML to PNG using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}