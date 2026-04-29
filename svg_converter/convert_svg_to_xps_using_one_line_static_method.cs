// Convert an SVG file to XPS using the one‑line Converter.ConvertSVG static method.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.svg";
            string outputPath = "output.xps";
            XpsSaveOptions options = new XpsSaveOptions();
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}