// Implement a progress reporter for batch conversion of SVG files to DOCX, showing percentage completed.

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
            string outputFolder = "OutputDocs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".docx");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                    Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
                    Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
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