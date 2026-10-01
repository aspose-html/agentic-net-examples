// Convert HTML to GIF while configuring resolution and rendering quality using ImageSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.gif";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, GIF!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}