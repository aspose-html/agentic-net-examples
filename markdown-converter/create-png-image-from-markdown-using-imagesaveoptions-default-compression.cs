// Create a PNG image from Markdown using ImageSaveOptions with ImageFormat.Png and default compression.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "sample.md";
            string savePath = "output.png";

            // Create a simple markdown file
            string markdownContent = "# Hello World\nThis is a **markdown** document.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set up image save options for PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTML to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Markdown has been converted to PNG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}