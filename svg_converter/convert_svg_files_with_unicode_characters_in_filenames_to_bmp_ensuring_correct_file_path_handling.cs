// Convert SVG files with Unicode characters in filenames to BMP, ensuring correct handling of file paths.

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
            // Folder containing SVG files (Unicode filenames are supported by .NET strings)
            string inputFolder = @"C:\InputSvgs";
            // Folder where BMP files will be saved
            string outputFolder = @"C:\OutputBmps";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each SVG file in the input folder
            foreach (string svgPath in Directory.GetFiles(inputFolder, "*.svg"))
            {
                // Build the output BMP file path with the same name but .bmp extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                string bmpPath = Path.Combine(outputFolder, fileNameWithoutExt + ".bmp");

                // Configure BMP output options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert the SVG file to BMP
                Converter.ConvertSVG(svgPath, options, bmpPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}