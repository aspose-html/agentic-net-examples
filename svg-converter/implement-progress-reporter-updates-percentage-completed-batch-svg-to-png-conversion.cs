// Implement a progress reporter that updates percentage completed during batch SVG to PNG conversion.

using System;
using System.IO;
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

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample SVG if none exist
            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg");
            if (svgFiles.Length == 0)
            {
                string sampleSvgPath = System.IO.Path.Combine(inputFolder, "sample.svg");
                string sampleSvgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue""/>
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange""/>
</svg>";
                System.IO.File.WriteAllText(sampleSvgPath, sampleSvgContent);
                svgFiles = new string[] { sampleSvgPath };
            }

            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = System.IO.Path.Combine(outputFolder,
                    System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                System.Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {System.IO.Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}