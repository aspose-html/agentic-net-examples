// Use Converter.ConvertSVG static method to batch convert an array of SVG paths into PNG files.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string[] svgPaths = new string[]
            {
                "input1.svg",
                "input2.svg"
            };

            foreach (var svgPath in svgPaths)
            {
                string outputPath = Path.ChangeExtension(svgPath, ".png");
                ImageSaveOptions options = new ImageSaveOptions();
                Converter.ConvertSVG(svgPath, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}