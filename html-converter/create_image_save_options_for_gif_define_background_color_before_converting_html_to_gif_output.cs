// Create an ImageSaveOptions for GIF and define background color before converting HTML to GIF output.

using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.gif";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello, GIF!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.BackgroundColor = Color.AliceBlue;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}