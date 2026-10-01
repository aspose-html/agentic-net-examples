// Render the converted HTML to PNG with a specific DPI setting for high‑resolution output.

using System;
using System.IO;
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
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            string htmlContent = File.ReadAllText(htmlPath);
            string baseUri = new Uri(Path.GetFullPath(htmlPath)).AbsoluteUri;

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, "output.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}