// Override default DPI to 72 when generating low‑resolution PNG previews of HTML content.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string htmlContent = System.IO.File.ReadAllText(htmlPath);
            string baseUri = new Uri(System.IO.Path.GetFullPath(htmlPath)).AbsoluteUri;
            var options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}