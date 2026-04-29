// Create a reusable utility class that encapsulates SVG to XPS conversion with configurable save options.

using System;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace SvgToXpsUtility
{
    // Reusable utility class for SVG to XPS conversion
    public static class SvgToXpsConverter
    {
        // Converts an SVG file to XPS with optional configuration of save options
        public static void Convert(string sourcePath, string outputPath, Action<XpsSaveOptions> configure = null)
        {
            // Create default XPS save options
            XpsSaveOptions options = new XpsSaveOptions();

            // Apply user-provided configuration if any
            configure?.Invoke(options);

            // Perform the conversion
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Example input and output paths
                string svgPath = "input.svg";
                string xpsPath = "output.xps";

                // Convert with custom options
                SvgToXpsConverter.Convert(svgPath, xpsPath, options =>
                {
                    // Set desired resolution and background color
                    options.HorizontalResolution = 200;
                    options.VerticalResolution = 200;
                    options.BackgroundColor = Color.AliceBlue;
                });

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
    }
}