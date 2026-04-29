// Ensure PNG images produced from Markdown have a minimum resolution of 300 DPI by setting ImageSaveOptions.

using System;
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
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}