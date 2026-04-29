// Specify XpsSaveOptions to enable lossless compression when converting SVG graphics to XPS documents.

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
            // Compression property is not available; default settings are used.
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}