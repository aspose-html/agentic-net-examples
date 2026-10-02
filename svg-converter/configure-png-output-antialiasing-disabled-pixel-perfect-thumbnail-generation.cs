// Configure ImageSaveOptions for PNG output with antialiasing disabled for pixel‑perfect thumbnail PNG generation process.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content for thumbnail generation
            System.String htmlContent = "<html><body><h1>Thumbnail</h1></body></html>";
            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for PNG with antialiasing disabled
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = false;

            // Output file path
            System.String outputPath = "thumbnail.png";

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Thumbnail PNG generated at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}