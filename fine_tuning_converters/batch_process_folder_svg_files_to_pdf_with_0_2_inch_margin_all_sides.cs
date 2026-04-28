// Batch process a folder of SVG files to PDF, applying a 0.2‑inch margin on all sides.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = @"C:\InputSvg";
            string outputFolder = @"C:\OutputPdf";

            // Ensure the output folder exists
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                // Determine output PDF file name
                string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileName + ".pdf");

                // Configure PDF save options with integer margins (approx. 0.2 inch)
                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(options.PageSetup.AnyPage.Size, new Margin(14, 14, 14, 14));

                // Convert SVG to PDF
                Converter.ConvertSVG(svgPath, options, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}