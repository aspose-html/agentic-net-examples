// Set image quality parameter in ImageSaveOptions while converting Markdown to JPEG with high fidelity.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "sample.md";
            string outputPath = "output.jpg";

            // Create a minimal markdown file
            string markdownContent = "# Hello World\nThis is a sample markdown converted to JPEG.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTMLDocument to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}