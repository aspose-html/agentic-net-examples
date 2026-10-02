// Set ImageSaveOptions color depth to 8 bits for GIF output to reduce file size.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, GIF!</h1></body></html>";
            string outputPath = "output.gif";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("GIF image saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}