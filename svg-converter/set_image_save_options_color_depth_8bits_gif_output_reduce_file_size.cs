// Set ImageSaveOptions color depth to 8 bits for GIF output to reduce file size.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample markdown file
            string markdownPath = "sample.md";
            if (!File.Exists(markdownPath))
            {
                string markdownContent = "# Sample Title\n\nThis is a **markdown** document converted to GIF.";
                File.WriteAllText(markdownPath, markdownContent);
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

            // Set up image save options for GIF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Define output path
            string outputPath = "output.gif";

            // Perform conversion to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed successfully. GIF saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}