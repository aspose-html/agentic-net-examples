// Render HTML content loaded from a string directly to PNG with specified DPI settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to render
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Base URI for the HTML content (required even if there are no relative resources)
            string baseUri = "about:blank";
            // Output PNG file path
            string outputPath = "output.png";

            // Configure image save options with PNG format and DPI settings
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML string to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}