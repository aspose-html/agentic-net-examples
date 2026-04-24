// Apply CSS media type “print” in ImageSaveOptions before converting HTML to JPEG for accurate print layout.

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
            string htmlPath = "input.html";
            string outputPath = "output.jpg";

            HTMLDocument document = new HTMLDocument(htmlPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.Css.MediaType = MediaType.Print;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}