// Set image quality parameter in ImageSaveOptions while converting Markdown to JPEG with high fidelity.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string sourcePath = "sample.md";
            string outputPath = "output.jpg";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Hello World\nThis is a sample markdown.";
                File.WriteAllText(sourcePath, markdownContent);
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for JPEG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            // Note: ImageSaveOptions does not expose a direct JPEG quality property in this API version.

            // Perform the conversion to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown has been successfully converted to JPEG: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}