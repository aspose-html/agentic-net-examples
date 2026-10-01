// Apply CSS media type “screen” in ImageSaveOptions before converting HTML to BMP for screen rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<html><head><style>body{background-color:lightblue;}</style></head><body><h1>Hello World</h1></body></html>");
            }

            string savePath = "output.bmp";

            HTMLDocument document = new HTMLDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.Css.MediaType = MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}