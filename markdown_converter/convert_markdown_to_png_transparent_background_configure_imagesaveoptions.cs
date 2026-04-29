// Convert Markdown to PNG with transparent background by configuring ImageSaveOptions appropriately.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string outputPath = "output.png";

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions();
            options.BackgroundColor = Color.Transparent;

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}