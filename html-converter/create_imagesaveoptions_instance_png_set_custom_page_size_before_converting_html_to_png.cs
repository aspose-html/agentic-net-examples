// Create an ImageSaveOptions instance for PNG and set custom page size before converting HTML to PNG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure image save options for PNG with custom page size
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.PageSetup.AnyPage = new Page(new Size(800, 600));

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}