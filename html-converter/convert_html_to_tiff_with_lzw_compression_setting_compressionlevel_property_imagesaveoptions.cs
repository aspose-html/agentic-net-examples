// Convert HTML to TIFF with LZW compression by setting CompressionLevel property in ImageSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            string outputPath = "output.tiff";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}