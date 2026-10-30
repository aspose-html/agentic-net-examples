// Batch convert SVG icons to PNG format at 128 px size for mobile application assets.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input";
            string outputDir = "output";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Sample SVG files
            string[] svgFiles = { "icon1.svg", "icon2.svg" };
            foreach (var file in svgFiles)
            {
                string inputPath = Path.Combine(inputDir, file);
                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"256\" height=\"256\"><rect width=\"256\" height=\"256\" fill=\"red\"/></svg>");
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(file) + ".png");

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 128;
                options.VerticalResolution = 128;
                options.UseAntialiasing = true;
                options.BackgroundColor = System.Drawing.Color.White;

                Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);
                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}