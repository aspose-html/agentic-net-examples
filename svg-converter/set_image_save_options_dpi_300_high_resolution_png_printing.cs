// Set ImageSaveOptions DPI to 300 for high‑resolution PNG printing applications.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Configure DPI using ImageSaveOptions
            var imageSaveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imageSaveOptions.HorizontalResolution = 300;
            imageSaveOptions.VerticalResolution = 300;

            // Read HTML content and base URI
            string htmlContent = File.ReadAllText(htmlPath);
            string baseUri = new Uri(Path.GetFullPath(htmlPath)).AbsoluteUri;

            // Output image path
            string outputImagePath = "output.jpg";

            // Convert HTML to image
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, imageSaveOptions, outputImagePath);
            Console.WriteLine($"HTML converted to image: {outputImagePath}");

            // EPUB conversion example (using an empty stream as placeholder)
            using (var epubStream = new MemoryStream())
            {
                // Normally load an actual EPUB file into the stream.
                var epubSaveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                epubSaveOptions.HorizontalResolution = 300;
                epubSaveOptions.VerticalResolution = 300;

                string epubOutputPath = "epub_output.png";

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, epubSaveOptions, epubOutputPath);
                Console.WriteLine($"EPUB converted to image: {epubOutputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}