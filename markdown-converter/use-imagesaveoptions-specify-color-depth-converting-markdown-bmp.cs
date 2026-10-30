// Use ImageSaveOptions to specify color depth when converting Markdown to BMP format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "### Hello, World!\n[visit applications](https://products.aspose.app/html/family)";

            // Create a temporary markdown file
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.md");
            File.WriteAllText(inputPath, markdown);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath);

            // Set up image save options for BMP format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            // Example of setting additional options (color depth is not directly supported)
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Define output BMP file path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.bmp");

            // Convert HTML to BMP image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. BMP saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}