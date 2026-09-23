// Configure ImageSaveOptions to set JPEG DPI to 300, then render a high‑resolution canvas and save.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>High‑Resolution Image</h1></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            var document = new Aspose.Html.HTMLDocument(htmlPath);

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}