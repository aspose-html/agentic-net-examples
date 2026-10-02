// Generate PNG snapshots of HTML pages at multiple DPI levels for responsive testing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><style>body{font-family:Arial;}</style></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a test page.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            int[] dpis = new int[] { 96, 150, 300 };
            foreach (int dpi in dpis)
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                {
                    HorizontalResolution = dpi,
                    VerticalResolution = dpi
                };
                string outputPath = $"snapshot_{dpi}dpi.png";
                Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}