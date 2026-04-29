// Convert multiple SVG files in a directory to XPS using a loop with Converter.ConvertSVG.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputXps";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            // Process each SVG file
            foreach (string svgPath in svgFiles)
            {
                // Build the output XPS file path
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string xpsPath = Path.Combine(outputFolder, fileName + ".xps");

                // Create default XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Convert the SVG file to XPS
                Converter.ConvertSVG(svgPath, options, xpsPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}