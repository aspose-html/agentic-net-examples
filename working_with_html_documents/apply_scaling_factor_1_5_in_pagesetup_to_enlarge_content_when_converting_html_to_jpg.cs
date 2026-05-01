// Apply scaling factor of 1.5 in PageSetup to enlarge content when converting HTML to JPG.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.jpg";

            HTMLDocument document = new HTMLDocument(htmlPath);

            double scale = 1.5;
            int baseWidth = 800;
            int baseHeight = 600;

            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.PageSetup.AnyPage = new Page(new Size((int)(baseWidth * scale), (int)(baseHeight * scale)));

            using (ImageDevice device = new ImageDevice(options, outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}