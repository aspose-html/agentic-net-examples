// Set CssOptions.MediaType to Screen when converting HTML to JPG to capture on‑screen appearance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            var document = new Aspose.Html.HTMLDocument(htmlPath);
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}