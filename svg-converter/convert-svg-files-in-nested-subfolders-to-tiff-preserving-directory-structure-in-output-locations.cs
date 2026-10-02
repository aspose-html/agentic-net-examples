// Convert SVG files located in nested subfolders to TIFF, preserving directory structure in output locations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputTiffs";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.AllDirectories);

            foreach (string svgPath in svgFiles)
            {
                string relativePath = System.IO.Path.GetRelativePath(inputFolder, svgPath);
                string outputDir = System.IO.Path.Combine(outputFolder, System.IO.Path.GetDirectoryName(relativePath) ?? string.Empty);
                if (!System.IO.Directory.Exists(outputDir))
                    System.IO.Directory.CreateDirectory(outputDir);

                string outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                Console.WriteLine($"Converted: {svgPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}