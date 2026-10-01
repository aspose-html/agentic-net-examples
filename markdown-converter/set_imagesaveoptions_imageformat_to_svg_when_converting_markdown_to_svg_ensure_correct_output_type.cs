// Set ImageSaveOptions.ImageFormat to Svg when converting Markdown to SVG to ensure correct output type.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Hello World";
            string outputPath = "output.svg";

            ImageSaveOptions options = new ImageSaveOptions();

            Aspose.Html.Converters.Converter.ConvertSVG(markdown, options, outputPath);

            Console.WriteLine("Markdown converted to SVG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}