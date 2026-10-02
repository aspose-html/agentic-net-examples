// Create a diagnostic log that records source SVG path, target format, and conversion duration.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputImages";
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".png");

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                stopwatch.Stop();
                double seconds = stopwatch.Elapsed.TotalSeconds;

                Console.WriteLine($"Converted {System.IO.Path.GetFileName(svgPath)} to PNG in {seconds:F2}s. Output: {System.IO.Path.GetFileName(outputPath)}");
                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Progress: {i + 1}/{total} ({percent}%)");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}