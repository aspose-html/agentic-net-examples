// Apply scaling factor of 0.5 in PageSetup to reduce size when converting HTML to JPG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

namespace Example
{
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
                    File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
                }

                // Configure image rendering options with a scaling factor of 0.5 (e.g., half size)
                ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
                options.PageSetup.AnyPage = new Page(new Size(400, 300)); // original size assumed 800x600, scaled to 0.5

                // Render HTML to JPEG
                using (ImageDevice device = new ImageDevice(options, outputPath))
                {
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        document.RenderTo(device);
                    }
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}