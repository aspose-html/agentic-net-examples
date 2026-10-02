// Batch convert a list of SVG files to various formats by iterating over save options programmatically.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\SvgInput";
            string outputFolder = @"C:\SvgOutput";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            int total = svgFiles.Length;
            string[] formats = new string[] { "png", "jpeg", "tiff" };

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    foreach (string fmt in formats)
                    {
                        Aspose.Html.Saving.ImageSaveOptions options;
                        switch (fmt)
                        {
                            case "jpeg":
                                options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                                break;
                            case "tiff":
                                options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                                break;
                            default: // png
                                options = new Aspose.Html.Saving.ImageSaveOptions();
                                break;
                        }

                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;
                        options.BackgroundColor = Color.White;
                        options.UseAntialiasing = true;

                        string outputPath = Path.Combine(outputFolder, $"{fileNameWithoutExt}.{fmt}");
                        Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                    }
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(svgPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}