// Leverage the default save options to quickly convert SVG to XPS without specifying additional parameters.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string sourcePath = "input.svg";

            // Desired path for the resulting XPS file
            string outputPath = "output.xps";

            // Create default XPS save options
            XpsSaveOptions options = new XpsSaveOptions();

            // Convert SVG to XPS using the default options
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}