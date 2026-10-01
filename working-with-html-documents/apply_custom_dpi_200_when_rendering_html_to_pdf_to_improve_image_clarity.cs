// Apply a custom DPI of 200 when rendering HTML to PDF to improve image clarity.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputHtmlPath = "sample.html";
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Read HTML content and base URI
            string htmlContent = File.ReadAllText(inputHtmlPath);
            string baseUri = new Uri(Path.GetFullPath(inputHtmlPath)).AbsoluteUri;

            // Convert HTML to JPEG image using Converter with DPI settings
            var imageSaveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imageSaveOptions.HorizontalResolution = 300;
            imageSaveOptions.VerticalResolution = 300;

            string outputImagePath = "output_image.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, imageSaveOptions, outputImagePath);
            Console.WriteLine($"HTML converted to image: {outputImagePath}");

            // Render HTML to image using ImageDevice (alternative approach)
            var document = new Aspose.Html.HTMLDocument(inputHtmlPath);
            var renderingOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            renderingOptions.UseAntialiasing = false;
            renderingOptions.HorizontalResolution = 300;
            renderingOptions.VerticalResolution = 300;

            var imageDevice = new Aspose.Html.Rendering.Image.ImageDevice(renderingOptions, "rendered_image.jpg");
            document.RenderTo(imageDevice);
            Console.WriteLine("HTML rendered to image via ImageDevice: rendered_image.jpg");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}