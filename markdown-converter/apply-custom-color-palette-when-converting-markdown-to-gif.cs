// Apply a custom color palette in ImageSaveOptions when converting Markdown to GIF format.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string outputPath = "output.gif";

            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Hello World\nThis is a sample markdown file.";
                File.WriteAllText(sourcePath, markdownContent);
            }

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.BackgroundColor = Color.AliceBlue;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown has been successfully converted to GIF at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}