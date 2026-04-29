// Batch convert a folder of SVG files to BMP format using a loop and Converter.ConvertSVG.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output folders
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputBmps";

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".bmp");

                // Configure BMP output options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert SVG to BMP
                Converter.ConvertSVG(svgPath, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}