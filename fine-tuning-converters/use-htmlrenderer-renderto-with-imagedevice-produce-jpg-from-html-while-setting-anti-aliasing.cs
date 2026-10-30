// Use HtmlRenderer.RenderTo with an ImageDevice to produce a JPG from HTML while setting anti‑aliasing.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            HTMLDocument document = new HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}