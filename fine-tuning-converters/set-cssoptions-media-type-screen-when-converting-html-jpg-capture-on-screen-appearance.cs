// Set CssOptions.MediaType to Screen when converting HTML to JPG to capture on‑screen appearance.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><head><style>body{background:#f0f0f0;}</style></head><body><h1>Hello World</h1></body></html>");
            }

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            var document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}