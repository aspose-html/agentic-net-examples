// Set ImageRenderingOptions.ResolutionDpi to 200 for moderate‑quality JPG conversion from HTML content in the resulting image.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.jpg";

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}