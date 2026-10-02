// Set the compression level in ImageSaveOptions when converting Markdown to PNG for web optimization.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a sample markdown file
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\nThis is a sample markdown.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set up image save options with PNG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            // Optional: configure rendering properties
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Define output PNG path
            string outputPath = "output.png";

            // Convert HTML document to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}