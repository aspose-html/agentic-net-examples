// Specify BitsPerPixel equal to 24 in ImageSaveOptions for true‑color BMP output.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, BMP!</h1></body></html>";
            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for BMP
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 400;
            options.VerticalResolution = 400;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            // Note: ImageSaveOptions does not expose a BitsPerPixel property in the current API,
            // so true‑color BMP output is achieved by using the BMP format without setting BitsPerPixel.

            // Output file path
            string outputPath = "output.bmp";

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine($"BMP image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}