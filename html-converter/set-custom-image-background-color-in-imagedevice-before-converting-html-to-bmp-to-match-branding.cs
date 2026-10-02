// Set custom image background color in ImageDevice before converting HTML to BMP to match branding.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            if (!System.IO.File.Exists(documentPath))
            {
                System.IO.File.WriteAllText(documentPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            string outputPath = "output.bmp";

            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.Bisque;

            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            Aspose.Html.Rendering.MhtmlRenderer renderer = new Aspose.Html.Rendering.MhtmlRenderer();

            using (System.IO.Stream stream = System.IO.File.OpenRead(documentPath))
            {
                renderer.Render(device, stream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}