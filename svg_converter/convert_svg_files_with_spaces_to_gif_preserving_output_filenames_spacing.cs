// Convert SVG files with spaces in their names to GIF, verifying that output filenames preserve spacing.

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
            // Folder containing SVG files
            string inputFolder = @"C:\InputSvgs";
            // Folder where GIF files will be saved
            string outputFolder = @"C:\OutputGifs";

            Directory.CreateDirectory(outputFolder);

            // Process each SVG file that has spaces in its name
            foreach (string svgPath in Directory.GetFiles(inputFolder, "*.svg"))
            {
                string fileName = Path.GetFileName(svgPath);
                if (!fileName.Contains(" "))
                    continue; // skip files without spaces

                // Preserve the original filename (including spaces) and change extension to .gif
                string gifFileName = Path.ChangeExtension(fileName, ".gif");
                string gifPath = Path.Combine(outputFolder, gifFileName);

                // Create GIF image save options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                // Convert SVG to GIF
                Converter.ConvertSVG(svgPath, options, gifPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}