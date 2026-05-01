// Add a meta viewport tag to improve mobile rendering, then convert the page to a high‑resolution PNG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string tempPath = "temp.html";

            // Read original HTML and inject viewport meta tag
            string html = File.ReadAllText(sourcePath);
            if (!html.Contains("<meta name=\"viewport\""))
            {
                html = html.Replace("<head>", "<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>");
            }
            File.WriteAllText(tempPath, html);

            // Load the modified HTML document
            using (HTMLDocument document = new HTMLDocument(tempPath))
            {
                // Set high‑resolution rendering options (300 DPI)
                ImageRenderingOptions options = new ImageRenderingOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };

                // Render to PNG
                using (ImageDevice device = new ImageDevice(options, "output.png"))
                {
                    document.RenderTo(device);
                }
            }

            // Clean up temporary file
            File.Delete(tempPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}