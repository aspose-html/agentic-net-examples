// Log each SVG to GIF conversion, recording output file size and applied image quality settings.

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
            string outputFolder = "OutputGifs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            foreach (string svgPath in svgFiles)
            {
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".gif");

                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Converter.ConvertSVG(svgPath, options, outputPath);

                FileInfo info = new FileInfo(outputPath);
                Console.WriteLine($"Converted '{Path.GetFileName(svgPath)}' to GIF. Size: {info.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}