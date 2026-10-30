// Convert HTML to XPS using XpsRenderingOptions to define custom top and bottom margins.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file and output XPS file paths
            string htmlPath = "sample.html";
            string xpsPath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure XPS rendering options with custom margins
            Aspose.Html.Rendering.Xps.XpsRenderingOptions options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            // Define page size (8.5 x 11 inches) and margins (top and bottom = 0.5 inch = 36 points)
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                new Aspose.Html.Drawing.Margin(0, 36, 0, 36));

            options.PageSetup.AnyPage = page;

            // Create XPS device and render the document
            Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, xpsPath);
            document.RenderTo(device);

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + xpsPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}