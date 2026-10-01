// Generate PNG snapshots of HTML pages at multiple DPI levels for responsive testing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string htmlPath = "sample.html";
        string outputLow = "output_50dpi.png";
        string outputHigh = "output_300dpi.png";

        // Create a minimal HTML file if it does not exist
        if (!File.Exists(htmlPath))
        {
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
        }

        try
        {
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                // Low DPI rendering (50 DPI)
                Aspose.Html.Rendering.Image.ImageRenderingOptions optionsLow = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                {
                    HorizontalResolution = 50,
                    VerticalResolution = 50
                };
                using (Aspose.Html.Rendering.Image.ImageDevice deviceLow = new Aspose.Html.Rendering.Image.ImageDevice(optionsLow, outputLow))
                {
                    document.RenderTo(deviceLow);
                }

                // High DPI rendering (300 DPI)
                Aspose.Html.Rendering.Image.ImageRenderingOptions optionsHigh = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };
                using (Aspose.Html.Rendering.Image.ImageDevice deviceHigh = new Aspose.Html.Rendering.Image.ImageDevice(optionsHigh, outputHigh))
                {
                    document.RenderTo(deviceHigh);
                }
            }

            Console.WriteLine("Rendering completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}