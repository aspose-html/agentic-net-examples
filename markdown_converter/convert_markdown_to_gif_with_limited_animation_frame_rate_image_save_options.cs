// Convert a Markdown file to GIF format while limiting the animation frame rate using ImageSaveOptions.

using System;
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
            string savePath = "output.gif";

            Aspose.Html.HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // Frame rate limitation is not available in the current API; default settings are used.

            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}