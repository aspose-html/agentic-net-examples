// Convert SVG to GIF with transparent background by configuring the conversion settings before execution.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare input and output folders
                string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input");
                string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
                if (!System.IO.Directory.Exists(inputFolder)) System.IO.Directory.CreateDirectory(inputFolder);
                if (!System.IO.Directory.Exists(outputFolder)) System.IO.Directory.CreateDirectory(outputFolder);

                // Create a minimal SVG file if it does not exist
                string sampleSvgPath = System.IO.Path.Combine(inputFolder, "sample.svg");
                if (!System.IO.File.Exists(sampleSvgPath))
                {
                    string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                    System.IO.File.WriteAllText(sampleSvgPath, svgContent);
                }

                // Batch convert all SVG files in the input folder to GIF images
                string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg");
                int total = svgFiles.Length;
                for (int i = 0; i < total; i++)
                {
                    string svgPath = svgFiles[i];
                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".gif");
                    using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                        options.HorizontalResolution = 96;
                        options.VerticalResolution = 96;
                        options.BackgroundColor = System.Drawing.Color.White;
                        options.UseAntialiasing = true;
                        Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                    }
                    int percent = (i + 1) * 100 / total;
                    System.Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {System.IO.Path.GetFileName(outputPath)}");
                }

                // Single conversion of the sample SVG to a high‑resolution TIFF image
                string tiffOutput = System.IO.Path.Combine(outputFolder, "sample.tiff");
                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sampleSvgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    tiffOptions.HorizontalResolution = 300;
                    tiffOptions.VerticalResolution = 300;
                    tiffOptions.BackgroundColor = System.Drawing.Color.White;
                    tiffOptions.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, tiffOptions, tiffOutput);
                }

                System.Console.WriteLine("All conversions completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}