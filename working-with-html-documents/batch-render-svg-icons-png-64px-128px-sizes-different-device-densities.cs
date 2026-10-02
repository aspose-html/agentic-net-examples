// Batch render SVG icons to PNG at 64 px and 128 px sizes for different device densities.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPngs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder); // Ensure folder exists; user can place SVGs here.

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string baseName = Path.GetFileNameWithoutExtension(svgPath);

                int[] sizes = new int[] { 64, 128 };
                foreach (int size in sizes)
                {
                    string outputPath = Path.Combine(outputFolder, $"{baseName}_{size}px.png");

                    using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                        options.HorizontalResolution = size;
                        options.VerticalResolution = size;
                        options.BackgroundColor = System.Drawing.Color.White;
                        options.UseAntialiasing = true;

                        Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                    }

                    Console.WriteLine($"Converted {i + 1}/{total} - {Path.GetFileName(outputPath)}");
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}