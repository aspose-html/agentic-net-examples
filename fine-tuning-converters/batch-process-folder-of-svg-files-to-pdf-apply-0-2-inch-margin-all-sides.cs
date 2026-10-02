// Batch process a folder of SVG files to PDF, applying a 0.2‑inch margin on all sides.

using System;
using System.IO;
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
            string outputFolder = "OutputPdfs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            int margin = 14; // 0.2 inch ≈ 14 points

            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(options.PageSetup.AnyPage.Size, new Margin(margin, margin, margin, margin));

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