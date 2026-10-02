// Create an ImageDevice for JPG output with anti‑aliasing enabled and a white background for clean visuals.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.BackgroundColor = System.Drawing.Color.White;
            string outputPath = "output.jpg";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}