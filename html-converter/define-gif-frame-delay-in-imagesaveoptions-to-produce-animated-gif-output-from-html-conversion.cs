// Define GIF frame delay in ImageSaveOptions to produce animated GIF output from HTML conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, GIF!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            // Note: The current Aspose.HTML API does not expose a property to set GIF frame delay.

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. GIF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}