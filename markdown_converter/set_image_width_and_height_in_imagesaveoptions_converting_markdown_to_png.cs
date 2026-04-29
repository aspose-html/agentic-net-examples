// Set image width and height in ImageSaveOptions when converting Markdown to a PNG file.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string savePath = "output.png";

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            ImageSaveOptions options = new ImageSaveOptions();
            options.PageSetup.AnyPage = new Page(new Size(800, 600), new Margin(0, 0, 0, 0));

            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}