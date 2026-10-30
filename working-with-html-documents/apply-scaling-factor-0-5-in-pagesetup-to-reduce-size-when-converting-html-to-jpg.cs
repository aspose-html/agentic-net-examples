// Apply scaling factor of 0.5 in PageSetup to reduce size when converting HTML to JPG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Configure image rendering options with scaling (half size)
                ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
                // Set the target page size to half of a typical 800x600 page (i.e., 400x300)
                options.PageSetup.AnyPage = new Page(new Size(400, 300));

                // Render the document to a JPEG image
                using (ImageDevice device = new ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}