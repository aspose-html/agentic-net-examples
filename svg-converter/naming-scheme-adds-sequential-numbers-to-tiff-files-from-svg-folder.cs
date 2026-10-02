// Create a naming scheme that adds sequential numbers to TIFF files generated from a folder of SVGs.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputTiffs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string baseName = Path.GetFileNameWithoutExtension(svgPath);
                string sequentialNumber = (i + 1).ToString("D3");
                string tiffFileName = $"{baseName}_{sequentialNumber}.tiff";
                string tiffPath = Path.Combine(outputFolder, tiffFileName);

                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.Compression = Compression.None;
                    options.UseAntialiasing = true;
                    options.BackgroundColor = System.Drawing.Color.White;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(tiffPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}