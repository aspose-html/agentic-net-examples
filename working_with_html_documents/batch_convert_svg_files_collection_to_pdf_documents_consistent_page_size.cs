// Batch convert a collection of SVG files to PDF documents with consistent page size settings.

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
            // Define input and output folders
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPdfs";

            // Ensure the output folder exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                // Build the output PDF file path
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                // Create PDF save options with integer margin values
                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    options.PageSetup.AnyPage.Size,
                    new Margin(20, 20, 20, 20) // left, top, right, bottom margins
                );

                // Convert the SVG to PDF
                Converter.ConvertSVG(svgPath, options, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}