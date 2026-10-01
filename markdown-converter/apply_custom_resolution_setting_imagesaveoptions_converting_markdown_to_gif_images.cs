// Apply a custom resolution setting in ImageSaveOptions when converting Markdown to GIF images.

using System;
using System.IO;

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
                File.WriteAllText(sourcePath, "# Sample Title\n\nThis is a **markdown** sample.");
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set image save options with custom resolution
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            // Convert HTMLDocument to GIF image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}