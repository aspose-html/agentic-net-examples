// Combine PageLayoutOptions.FitToContentWidth and FitToContentHeight to match both width and height to HTML content.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Define file paths
            string documentPath = Path.Combine(inputDir, "sample.html");
            string savePath = Path.Combine(outputDir, "output.jpg");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath))
            {
                // Configure rendering options
                Aspose.Html.Rendering.Image.ImageRenderingOptions opt = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                opt.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth |
                                                  Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;
                opt.HorizontalResolution = 96;
                opt.VerticalResolution = 96;
                opt.BackgroundColor = System.Drawing.Color.White;

                // Render to image file
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(opt, savePath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine($"Image successfully saved to: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}