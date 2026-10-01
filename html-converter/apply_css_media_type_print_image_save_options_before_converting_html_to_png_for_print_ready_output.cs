// Apply CSS media type “print” in ImageSaveOptions before converting HTML to PNG for print‑ready output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Print!</h1></body></html>");
            }

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Print;

            var document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}