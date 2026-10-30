// Add a meta viewport tag to improve mobile rendering, then convert the page to a high‑resolution PNG.

using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare a minimal HTML file
                string htmlPath = "sample.html";
                if (!File.Exists(htmlPath))
                {
                    File.WriteAllText(htmlPath,
                        "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose HTML</h1></body></html>");
                }

                // Render to PNG with default resolution
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Rendering.Image.ImageRenderingOptions options1 = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                    {
                        HorizontalResolution = 96,
                        VerticalResolution = 96
                    };
                    string outputPath1 = "output1.png";
                    using (Aspose.Html.Rendering.Image.ImageDevice device1 = new Aspose.Html.Rendering.Image.ImageDevice(options1, outputPath1))
                    {
                        document.RenderTo(device1);
                    }
                }

                // Render to JPEG with custom settings
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Rendering.Image.ImageRenderingOptions options2 = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg)
                    {
                        UseAntialiasing = false,
                        HorizontalResolution = 150,
                        VerticalResolution = 150
                    };
                    string outputPath2 = "output2.jpg";
                    using (Aspose.Html.Rendering.Image.ImageDevice device2 = new Aspose.Html.Rendering.Image.ImageDevice(options2, outputPath2))
                    {
                        document.RenderTo(device2);
                    }
                }

                Console.WriteLine("Rendering completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}