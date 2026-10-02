// Render the converted HTML to PNG with a specific DPI setting for high‑resolution output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";

            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            string outputPath = "output.png";

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}