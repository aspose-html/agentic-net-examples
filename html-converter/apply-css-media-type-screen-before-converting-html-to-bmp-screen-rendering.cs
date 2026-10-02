// Apply CSS media type “screen” in ImageSaveOptions before converting HTML to BMP for screen rendering.

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.bmp";

            if (!System.IO.File.Exists(documentPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>";
                System.IO.File.WriteAllText(documentPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            System.Console.WriteLine("Conversion completed. Output saved to " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}