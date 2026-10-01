// Convert HTML to PNG with custom CSS font fallback to ensure text renders when primary font missing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare fonts lookup folder (can be empty if no custom fonts are needed)
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
            Directory.CreateDirectory(fontsFolder);

            // Create a sample HTML file with a primary font that may be missing and a fallback
            string htmlContent = "<!DOCTYPE html><html><head><style>body{font-family:'CustomFont','Arial',sans-serif;}</style></head><body><p>Hello, world!</p></body></html>";
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Configure Aspose.HTML to use the custom fonts folder
            var configuration = new Aspose.Html.Configuration();
            var userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Load the HTML document with the custom configuration
            var document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Set image save options for PNG output
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = true;

            // Define output PNG file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}