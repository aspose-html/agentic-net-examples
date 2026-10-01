// Use ImageDevice with a fixed 1024 by 768 pixel canvas to render HTML to PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML content and write to a temporary file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Define output image path
            string outputPath = "output.png";

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options for PNG format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"HTML has been converted to PNG and saved at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}