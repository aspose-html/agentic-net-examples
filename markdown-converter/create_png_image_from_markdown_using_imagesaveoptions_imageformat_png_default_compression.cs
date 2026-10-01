// Create a PNG image from Markdown using ImageSaveOptions with ImageFormat.Png and default compression.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample markdown file
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\nThis is a **markdown** sample.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set up image save options for PNG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Define output image path
            string outputPath = "output.png";

            // Convert HTML document to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PNG image created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}