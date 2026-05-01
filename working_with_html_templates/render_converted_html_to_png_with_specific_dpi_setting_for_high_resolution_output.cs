// Render the converted HTML to PNG with a specific DPI setting for high‑resolution output.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.png";
            string htmlContent = System.IO.File.ReadAllText(htmlPath);
            string baseUri = new Uri(System.IO.Path.GetFullPath(htmlPath)).AbsoluteUri;

            var options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}