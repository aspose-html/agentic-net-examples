// Implement a progress reporter for batch conversion of SVG files to DOCX, showing percentage completed.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "./InputSvg";
            string outputFolder = "./OutputDocx";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = System.IO.Path.Combine(outputFolder,
                    System.IO.Path.GetFileNameWithoutExtension(svgPath) + ".docx");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                    Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
                    Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72); // 1 inch margins
                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                    options.PageSetup.AnyPage = page;

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