// Log each SVG to GIF conversion, recording output file size and applied image quality settings.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputSvgs");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputGifs");

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample SVG file if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>");
                existingSvgs = new string[] { sampleSvgPath };
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".gif");

                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

                long fileSize = new FileInfo(outputPath).Length;
                Console.WriteLine($"Converted {Path.GetFileName(svgPath)} to GIF. Size: {fileSize} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}