// Set custom DPI of 300 in ImageSaveOptions before converting HTML to PNG for high‑resolution printing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            var document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}