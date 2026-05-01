// Apply custom PixelsPerInch value only for a single conversion operation without affecting global settings.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

namespace CustomDpiConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string outputPath = "output.png";
                double customDpi = 150.0;

                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure rendering options with a custom DPI
                    ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Png)
                    {
                        HorizontalResolution = (int)customDpi,
                        VerticalResolution = (int)customDpi
                    };

                    // Create an image device using the options
                    using (ImageDevice device = new ImageDevice(options, outputPath))
                    {
                        // Render the document to the image device
                        document.RenderTo(device);
                    }
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}