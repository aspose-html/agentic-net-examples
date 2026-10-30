// Create a PNG image from Markdown using ImageSaveOptions with ImageFormat.Png and default compression.

using System;
using System.IO;
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
            string markdownContent = "# Hello World\nThis is a **markdown** sample.";
            File.WriteAllText(sourcePath, markdownContent);

            string savePath = "output.png";

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("PNG image saved to " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}