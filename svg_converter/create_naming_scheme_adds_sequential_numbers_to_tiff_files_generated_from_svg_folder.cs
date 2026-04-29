// Create a naming scheme that adds sequential numbers to TIFF files generated from a folder of SVGs.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputTiffs";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string baseName = Path.GetFileNameWithoutExtension(svgPath);
                string tiffPath = Path.Combine(outputFolder, $"{baseName}_{i + 1}.tiff");
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                Converter.ConvertSVG(svgPath, options, tiffPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}