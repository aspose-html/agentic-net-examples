// Create a Windows service that converts incoming Markdown emails to PNG attachments in real time.

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
            string markdownContent = "# Hello World\nThis is a **markdown** sample.";
            File.WriteAllText(markdownPath, markdownContent);

            // Convert markdown to HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

            // Set image save options for PNG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTML document to PNG image
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}