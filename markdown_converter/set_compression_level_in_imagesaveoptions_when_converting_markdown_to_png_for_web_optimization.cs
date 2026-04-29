// Set the compression level in ImageSaveOptions when converting Markdown to PNG for web optimization.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string savePath = "output.png";

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}