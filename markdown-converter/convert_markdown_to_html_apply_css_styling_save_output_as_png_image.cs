// Convert Markdown to HTML, apply CSS styling, and then save the output as a PNG image.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Create a sample markdown file
            string markdownContent = "# Hello World\r\nThis is a **markdown** sample.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Apply CSS styling
            string css = "body { font-family: Arial; background-color: #f0f0f0; } h1 { color: #ff0000; }";
            Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }
            Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
            styleElement.TextContent = css;
            head.AppendChild(styleElement);

            // Set image save options for PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTML to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. PNG saved at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}