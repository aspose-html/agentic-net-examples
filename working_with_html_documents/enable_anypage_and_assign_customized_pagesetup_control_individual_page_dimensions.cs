// Enable RenderingOptions.AnyPage and assign a customized PageSetup to control individual page dimensions.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.png";

            HTMLDocument document = new HTMLDocument(htmlPath);
            ImageRenderingOptions opt = new ImageRenderingOptions();
            opt.PageSetup.AnyPage = new Page(new Size(200, 200));

            using (ImageDevice device = new ImageDevice(opt, outputPath))
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