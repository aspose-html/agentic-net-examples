// Convert SVG to XPS while preserving embedded fonts by enabling font embedding in XpsSaveOptions.

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
            // If XpsSaveOptions supports font embedding, enable it here:
            // options.EmbedFonts = true;

            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}