// Apply a custom color palette in ImageSaveOptions when converting Markdown to GIF format.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and output GIF path
            string sourcePath = "sample.md";
            string outputPath = "output.gif";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Title\n\nThis is a **markdown** example.");
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for GIF with a custom background color
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.BackgroundColor = Color.AliceBlue; // custom color as part of palette

            // Perform the conversion to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Markdown has been successfully converted to GIF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}