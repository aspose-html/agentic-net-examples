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
    static async Task Main(string[] args)
    {
        try
        {
            await ConvertMarkdownToJpegAsync();
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertMarkdownToJpegAsync()
    {
        // Define input markdown file and output JPEG path
        string sourcePath = "sample.md";
        string savePath = "output.jpg";

        // Sample markdown content
        string code = "# Hello World\nThis is a **markdown** sample.";

        // Write markdown content to file
        File.WriteAllText(sourcePath, code);

        // Convert markdown file to HTMLDocument
        HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

        // Configure image save options for JPEG
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
        options.UseAntialiasing = true;

        // Perform the conversion on a background thread
        await Task.Run(() =>
        {
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        });
    }
}