// Implement a progress reporter for SVG to TIFF batch conversion, indicating compression level for each file.

using System;
using System.IO;

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

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Optional: create a sample SVG if none exist
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            if (svgFiles.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
                    @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
                        <rect width='200' height='200' fill='red' />
                      </svg>");
                svgFiles = new string[] { sampleSvgPath };
            }

            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                using (Aspose.Html.Dom.Svg.SVGDocument document =
                    new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options =
                        new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine(
                    $"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)} (Compression: {Aspose.Html.Rendering.Image.Compression.None})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}