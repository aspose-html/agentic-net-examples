// Convert HTML to PNG after injecting custom JavaScript that modifies the DOM for dynamic content.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content with custom JavaScript that modifies the DOM
            string htmlContent = "<html><head><script>document.body.innerHTML = '<h1>Dynamic Content</h1>';</script></head><body></body></html>";
            // Base URI required by the converter (can be a dummy value)
            string baseUri = "file:///";
            // Configure image save options for PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            // Output PNG file path
            string outputPath = "output.png";
            // Convert the HTML (with injected script) to PNG
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}