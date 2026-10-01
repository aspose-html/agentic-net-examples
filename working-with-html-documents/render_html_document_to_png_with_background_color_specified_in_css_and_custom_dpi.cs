// Render an HTML document to PNG with a background color specified in CSS and custom DPI.

using System;
using System.IO;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output paths
                string inputHtmlPath = "sample.html";
                string outputImagePath = "output.jpg";

                // Create a minimal HTML file if it does not exist
                if (!File.Exists(inputHtmlPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1 style='color:blue;'>Hello Aspose HTML</h1></body></html>";
                    File.WriteAllText(inputHtmlPath, sampleHtml);
                }

                // Read HTML content and determine base URI
                string htmlContent = File.ReadAllText(inputHtmlPath);
                string baseUri = new Uri(Path.GetFullPath(inputHtmlPath)).AbsoluteUri;

                // Configure image save options
                Aspose.Html.Saving.ImageSaveOptions saveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                saveOptions.HorizontalResolution = 300;
                saveOptions.VerticalResolution = 300;
                saveOptions.BackgroundColor = System.Drawing.Color.Beige;
                saveOptions.UseAntialiasing = false;

                // Convert HTML to image
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, saveOptions, outputImagePath);

                Console.WriteLine($"Image saved to: {Path.GetFullPath(outputImagePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}