// Convert HTML string containing embedded base64 images to JPEG while preserving image quality.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content with embedded base64 image
            string htmlContent = "<html><body><h1>Sample</h1><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA...\" /></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Configure JPEG save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Define output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.jpg");

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}