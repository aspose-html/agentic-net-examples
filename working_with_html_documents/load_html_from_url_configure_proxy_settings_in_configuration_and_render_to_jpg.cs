// Load HTML from a URL, configure proxy settings in Configuration, and render to JPG.

using System;
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
            var sourceUrl = new Aspose.Html.Url("https://example.com");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            string outputPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(sourceUrl, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}