// Override default DPI to 72 when generating low‑resolution PNG previews of HTML content.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "sample.html";
            string outputPathConverter = "output_converter.jpg";
            string outputPathDevice1 = "output_device1.jpg";
            string outputPathDevice2 = "output_device2.jpg";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Read HTML content and determine base URI
            string htmlContent = File.ReadAllText(inputPath);
            string baseUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;

            // Configure DPI using ImageSaveOptions
            var saveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            saveOptions.HorizontalResolution = 300;
            saveOptions.VerticalResolution = 300;

            // Convert HTML to image using the Converter API
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, saveOptions, outputPathConverter);

            // Load the HTML document for rendering with ImageDevice
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // First rendering with specific DPI
            var renderingOptions1 = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 150,
                VerticalResolution = 150
            };
            var device1 = new Aspose.Html.Rendering.Image.ImageDevice(renderingOptions1, outputPathDevice1);
            document.RenderTo(device1);

            // Second rendering with different DPI
            var renderingOptions2 = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 72,
                VerticalResolution = 72
            };
            var device2 = new Aspose.Html.Rendering.Image.ImageDevice(renderingOptions2, outputPathDevice2);
            document.RenderTo(device2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}