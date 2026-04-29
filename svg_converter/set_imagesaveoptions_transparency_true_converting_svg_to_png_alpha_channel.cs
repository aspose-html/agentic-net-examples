// Set ImageSaveOptions transparency to true when converting SVG to PNG with alpha channel.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.svg";
            string outputPath = "output.png";

            ImageSaveOptions options = new ImageSaveOptions();
            options.BackgroundColor = Color.Transparent;

            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}