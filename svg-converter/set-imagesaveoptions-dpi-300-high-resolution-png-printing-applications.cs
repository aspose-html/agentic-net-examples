// Set ImageSaveOptions DPI to 300 for high‑resolution PNG printing applications.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            System.Console.WriteLine("Image saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}