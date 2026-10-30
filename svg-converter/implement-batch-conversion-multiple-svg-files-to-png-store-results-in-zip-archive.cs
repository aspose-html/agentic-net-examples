// Implement batch conversion of multiple SVG files to PNG and store results in a zip archive.

using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPngs";
            string zipPath = "ConvertedSvgs.zip";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample SVG if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
</svg>");
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // Create ZIP archive of the PNG files
            using (FileStream zipFileStream = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive zip = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
            {
                string[] pngFiles = Directory.GetFiles(outputFolder, "*.png");
                foreach (string pngPath in pngFiles)
                {
                    string entryName = Path.GetFileName(pngPath);
                    zip.CreateEntryFromFile(pngPath, entryName);
                }
            }

            Console.WriteLine($"All PNG files have been zipped into '{zipPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}