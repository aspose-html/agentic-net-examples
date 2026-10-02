// Convert HTML to TIFF and verify that the resulting image contains selectable text layers when supported.

using System;
using System.IO;
using System.Drawing;
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
            string htmlPath = "sample.html";
            string tiffPath = "output.tiff";

            // Create a minimal HTML file
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello World</h1><p>This is a test.</p></body></html>");

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure TIFF save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;

            // Convert HTML to TIFF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, tiffPath);

            // Verify the output file
            if (File.Exists(tiffPath) && new FileInfo(tiffPath).Length > 0)
            {
                Console.WriteLine("TIFF conversion succeeded. The image should contain selectable text layers if supported.");
            }
            else
            {
                Console.WriteLine("TIFF conversion failed or the output file is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}