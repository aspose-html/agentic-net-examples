// Convert HTML to PNG with custom CSS font fallback to ensure text renders when primary font missing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a primary font that may be missing and a fallback font.
            string htmlContent = "<!DOCTYPE html><html><head><style>body{font-family:'NonExistentFont', Arial;}</style></head><body><p>Hello, world!</p></body></html>";
            string inputPath = "sample.html";
            string outputPath = "output.png";

            // Write the HTML content to a temporary file.
            File.WriteAllText(inputPath, htmlContent);

            // Create configuration and set a fonts lookup folder (fallback fonts can be placed here).
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder("fonts", true);

            // Load the HTML document from the file using the configuration.
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration);

            // Set image save options for PNG format.
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = true;

            // Convert HTML to PNG.
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output file: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}