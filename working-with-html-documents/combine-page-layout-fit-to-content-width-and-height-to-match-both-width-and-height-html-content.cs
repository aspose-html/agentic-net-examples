// Combine PageLayoutOptions.FitToContentWidth and FitToContentHeight to match both width and height to HTML content.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = Path.Combine(Environment.CurrentDirectory, "sample.html");
                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.jpg");

                if (!File.Exists(inputPath))
                {
                    string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample.</p></body></html>";
                    File.WriteAllText(inputPath, htmlContent);
                }

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    Aspose.Html.Rendering.Image.ImageRenderingOptions opt = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    opt.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth | Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

                    Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(opt, outputPath);
                    document.RenderTo(device);
                }

                Console.WriteLine("Image saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}