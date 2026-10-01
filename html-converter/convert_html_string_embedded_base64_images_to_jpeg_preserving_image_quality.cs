// Convert HTML string containing embedded base64 images to JPEG while preserving image quality.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=\" /></body></html>";
            string outputPath = "output.jpg";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, ".");

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}