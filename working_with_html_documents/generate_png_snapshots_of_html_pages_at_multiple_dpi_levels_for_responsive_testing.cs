// Generate PNG snapshots of HTML pages at multiple DPI levels for responsive testing.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Output file paths for different DPI levels
            string outputLowDpi = "output_50dpi.png";
            string outputHighDpi = "output_300dpi.png";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Render at low resolution (50 DPI)
                ImageRenderingOptions lowDpiOptions = new ImageRenderingOptions()
                {
                    HorizontalResolution = 50,
                    VerticalResolution = 50
                };
                using (ImageDevice lowDpiDevice = new ImageDevice(lowDpiOptions, outputLowDpi))
                {
                    document.RenderTo(lowDpiDevice);
                }

                // Render at high resolution (300 DPI)
                ImageRenderingOptions highDpiOptions = new ImageRenderingOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };
                using (ImageDevice highDpiDevice = new ImageDevice(highDpiOptions, outputHighDpi))
                {
                    document.RenderTo(highDpiDevice);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}