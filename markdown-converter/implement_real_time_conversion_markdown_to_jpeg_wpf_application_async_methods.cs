// Implement real‑time conversion of Markdown to JPEG within a WPF application using async methods.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            await ConvertMarkdownToJpegAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertMarkdownToJpegAsync()
    {
        // Define paths
        string sourcePath = "sample.md";
        string savePath = "output.jpg";

        // Create a sample markdown file
        string markdownContent = "# Hello World\nThis is a **markdown** sample.";
        File.WriteAllText(sourcePath, markdownContent);

        // Convert markdown to HTMLDocument
        var document = await Task.Run(() =>
            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath));

        // Set JPEG save options
        var options = new Aspose.Html.Saving.ImageSaveOptions(
            Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

        // Convert HTMLDocument to JPEG file
        await Task.Run(() =>
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath));

        Console.WriteLine($"Markdown has been converted to JPEG at: {Path.GetFullPath(savePath)}");
    }
}