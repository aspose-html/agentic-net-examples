// Convert HTML strings directly to GIF images using static conversion method and specifying output path.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, GIF!</h1></body></html>";
            string outputPath = "output.gif";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed. Image saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}