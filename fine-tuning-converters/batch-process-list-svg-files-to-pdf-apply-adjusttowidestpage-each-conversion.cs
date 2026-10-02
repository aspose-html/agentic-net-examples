// Batch process a list of SVG files to PDF, applying AdjustToWidestPage to each conversion.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPdfs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                var options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    options.PageSetup.AnyPage.Size,
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
                Console.WriteLine($"Converted: {Path.GetFileName(svgPath)} -> {Path.GetFileName(pdfPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}