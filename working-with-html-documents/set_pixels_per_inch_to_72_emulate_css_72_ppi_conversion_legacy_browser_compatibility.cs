// Set PixelsPerInch to 72 to emulate CSS 72 PPI conversion for legacy browser compatibility.

class Program
{
    static void Main()
    {
        try
        {
            double customDpi = 72;
            string html = "<html><body><h1>Hello World</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html))
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
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}