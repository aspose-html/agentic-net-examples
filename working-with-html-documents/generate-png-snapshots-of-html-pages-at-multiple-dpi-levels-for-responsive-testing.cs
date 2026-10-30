// Generate PNG snapshots of HTML pages at multiple DPI levels for responsive testing.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            int[] dpis = new int[] { 96, 300 };
            foreach (int dpi in dpis)
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                {
                    HorizontalResolution = dpi,
                    VerticalResolution = dpi
                };

                string outputPath = $"output_{dpi}dpi.png";
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