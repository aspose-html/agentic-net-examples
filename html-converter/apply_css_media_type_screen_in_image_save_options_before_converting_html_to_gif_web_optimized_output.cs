// Apply CSS media type “screen” in ImageSaveOptions before converting HTML to GIF for web‑optimized output.

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}