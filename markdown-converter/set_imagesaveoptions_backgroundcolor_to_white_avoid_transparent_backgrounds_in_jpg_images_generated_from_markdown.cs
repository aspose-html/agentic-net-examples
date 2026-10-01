// Set ImageSaveOptions.BackgroundColor to white to avoid transparent backgrounds in JPG images generated from Markdown.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string outputPath = "output.jpg";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a sample markdown file converted to an image.");
            }

            var document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}