// Render an HTML document to XPS with landscape orientation by setting XpsRenderingOptions.PageOrientation.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string documentPath = "input.html";

            // Path where the XPS file will be saved
            string savePath = "output.xps";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create rendering options for XPS
            XpsRenderingOptions options = new XpsRenderingOptions();

            // Define a landscape page (width > height) – 11 inches wide, 8.5 inches tall
            Page landscapePage = new Page(
                new Size(
                    Length.FromInches(11),
                    Length.FromInches(8.5)));

            // Apply the page setup to the rendering options
            options.PageSetup.AnyPage = landscapePage;

            // Create an XPS device with the configured options and output path
            XpsDevice device = new XpsDevice(options, savePath);

            // Render the HTML document to the XPS device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}