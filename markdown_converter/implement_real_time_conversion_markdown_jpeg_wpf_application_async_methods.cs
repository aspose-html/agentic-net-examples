// Implement real‑time conversion of Markdown to JPEG within a WPF application using async methods.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static async Task Main()
    {
        try
        {
            // Define paths for the markdown source and the resulting JPEG image
            string sourcePath = "sample.md";
            string savePath = "output.jpg";

            // Write sample markdown content to the source file asynchronously
            string markdownContent = "# Hello Aspose\nThis is a **markdown** document.";
            await File.WriteAllTextAsync(sourcePath, markdownContent);

            // Convert markdown to an HTMLDocument (CPU‑bound, run on a background thread)
            HTMLDocument document = await Task.Run(() => Converter.ConvertMarkdown(sourcePath));

            // Configure image saving options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Render the HTMLDocument to a JPEG image (CPU‑bound, run on a background thread)
            await Task.Run(() => Converter.ConvertHTML(document, options, savePath));

            Console.WriteLine($"Markdown has been converted to JPEG and saved at '{savePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}