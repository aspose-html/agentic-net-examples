// Batch convert a collection of SVG files to PDF, preserving vector fidelity for printing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPdfs";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a minimal SVG file if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(sampleSvgPath, svgContent);
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(options.PageSetup.AnyPage.Size, new Margin(0, 0, 0, 0));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
                Console.WriteLine($"Converted '{svgPath}' to '{pdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}