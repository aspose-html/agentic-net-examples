// Create an HTML document, add a meta viewport for responsive design, and test on mobile rendering.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body><h1>Hello Mobile!</h1><p>This is a test.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = false;
            options.VerticalResolution = Aspose.Html.Drawing.Resolution.FromDotsPerInch(96);
            options.HorizontalResolution = Aspose.Html.Drawing.Resolution.FromDotsPerInch(96);
            string outputPath = "output_mobile.jpg";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);
            System.Console.WriteLine("Rendering completed: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}