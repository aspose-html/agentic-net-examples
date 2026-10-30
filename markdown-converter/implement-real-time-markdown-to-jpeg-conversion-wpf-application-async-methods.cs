// Implement real‑time conversion of Markdown to JPEG within a WPF application using async methods.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.md";
            string savePath = "output.jpg";

            // Sample markdown content
            string code = "# Sample Title\n\nThis is a **markdown** document.";

            // Write markdown content to file
            await File.WriteAllTextAsync(sourcePath, code);

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for JPEG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Perform conversion to JPEG (wrapped in Task.Run for async behavior)
            await Task.Run(() => Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath));

            Console.WriteLine($"Markdown successfully converted to JPEG: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}