// Use custom PixelsPerInch to simulate high‑density displays when converting pixels to inches.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 300.0;
            double customDpi = 200.0;
            double inches = pixels / customDpi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Pixels: {pixels}, Custom DPI: {customDpi}, Inches: {inches:F4}");

            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, "<html><body><h1>Sample</h1></body></html>");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                {
                    HorizontalResolution = (int)customDpi,
                    VerticalResolution = (int)customDpi
                };

                string outputPath = "output.png";
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}