// Batch process SVG files to DOCX format, ensuring each document retains vector graphic fidelity after conversion.

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
            // Define input and output directories
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputDocs";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string svgPath in svgFiles)
            {
                // Build the output DOCX file path
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".docx");

                // Create default DOCX save options
                DocSaveOptions options = new DocSaveOptions();

                // Convert the SVG file to DOCX, preserving vector fidelity
                Converter.ConvertSVG(svgPath, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}