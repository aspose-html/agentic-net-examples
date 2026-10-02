// Convert HTML strings directly to TIFF images using one‑line static conversion with custom options.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, TIFF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            string outputPath = "output.tiff";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed. File saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}