// Convert HTML containing external CSS files to PNG while ensuring base URL is set for correct resource loading.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare resources folder
            string resourcesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            Directory.CreateDirectory(resourcesFolder);

            // Create external CSS file
            string cssPath = Path.Combine(resourcesFolder, "styles.css");
            File.WriteAllText(cssPath, "h1 { color: red; }");

            // HTML content referencing the external CSS
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><h1>Hello World</h1></body></html>";

            // Base URL for loading external resources
            string baseUrl = new Uri(resourcesFolder + Path.DirectorySeparatorChar).AbsoluteUri;

            // Load HTML document with base URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUrl);

            // Set image save options for PNG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Output PNG file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}