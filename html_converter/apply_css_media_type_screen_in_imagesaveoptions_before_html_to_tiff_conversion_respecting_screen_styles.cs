// Apply CSS media type “screen” in ImageSaveOptions before converting HTML to TIFF to respect screen styles.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument("input.html");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.tiff");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}