// Batch process a list of SVG files to PDF, applying AdjustToWidestPage to each conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input folder containing SVG files
            string inputFolder = "InputSvgs";
            // Output folder for generated PDF files
            string outputFolder = "OutputPdfs";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                // Determine output PDF file name
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                // Create PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Apply AdjustToWidestPage setting
                options.PageSetup.AdjustToWidestPage = true;

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