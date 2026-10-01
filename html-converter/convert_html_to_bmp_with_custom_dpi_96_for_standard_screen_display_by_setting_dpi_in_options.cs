// Convert HTML to BMP with custom DPI of 96 for standard screen display by setting DPI in options.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.bmp";

            if (!System.IO.File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.UseAntialiasing = false;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}