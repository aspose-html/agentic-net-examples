// Batch process a folder of SVG files to PDF, applying a 0.2‑inch margin on all sides.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputPdfs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // 0.2 inch margin = 0.2 * 72 points ≈ 14 points (int)
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    options.PageSetup.AnyPage.Size,
                    new Aspose.Html.Drawing.Margin(14, 14, 14, 14));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}