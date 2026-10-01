// Render the final HTML to PNG with transparent background using appropriate rendering options.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = string.Empty;

            // Output image path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure image save options (PNG format via constructor)
            var imageSaveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
            {
                UseAntialiasing = true,
                HorizontalResolution = 300,
                VerticalResolution = 300,
                BackgroundColor = System.Drawing.Color.Bisque
            };

            // Perform conversion from HTML string to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, imageSaveOptions, outputPath);

            Console.WriteLine($"HTML has been successfully converted to image: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}