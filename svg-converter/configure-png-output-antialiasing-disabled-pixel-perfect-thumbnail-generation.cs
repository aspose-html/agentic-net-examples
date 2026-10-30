// Configure ImageSaveOptions for PNG output with antialiasing disabled for pixel‑perfect thumbnail PNG generation process.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = false;
            string outputPath = "thumbnail.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine("Thumbnail PNG generated at: " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}