// Implement a progress reporter for batch conversion of SVG files to DOCX, showing percentage completed.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputDocx";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".docx");
                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    DocSaveOptions options = new DocSaveOptions();
                    Size size = new Size(500, 500);
                    Margin margin = new Margin(30, 10, 10, 10);
                    Page page = new Page(size, margin);
                    options.PageSetup.AnyPage = page;
                    Converter.ConvertSVG(document, options, outputPath);
                }
                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}