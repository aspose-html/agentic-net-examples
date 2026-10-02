// Convert HTML containing external CSS files to PNG while ensuring base URL is set for correct resource loading.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input folder
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputFolder);

            // Write CSS file
            string cssPath = Path.Combine(inputFolder, "styles.css");
            File.WriteAllText(cssPath, "h1 { color: red; }");

            // HTML content referencing the CSS file
            string htmlContent = "<html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><h1>Hello World</h1></body></html>";

            // Base URI for the document (folder path)
            string baseUri = new Uri(inputFolder + Path.DirectorySeparatorChar).AbsoluteUri;

            // Create HTMLDocument with content and base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set image save options for PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}