// Convert Markdown to HTML, apply CSS styling, and then save the output as a PNG image.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\r\nThis is a **markdown** sample.";
            File.WriteAllText(sourcePath, markdownContent);

            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
            styleElement.TextContent = "body { font-family: Arial; background-color: #f0f0f0; } h1 { color: #ff0000; }";
            head.AppendChild(styleElement);

            string outputPath = "output.png";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. PNG saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}