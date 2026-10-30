// Enable high compression in ImageSaveOptions when generating BMP for archival purposes.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello BMP</h1></body></html>";
            string outputPath = "archival_output.bmp";

            // Load HTML from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for BMP with high resolution
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 400;
            options.VerticalResolution = 400;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert HTML to BMP
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"BMP image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}