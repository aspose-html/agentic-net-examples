// Create a naming convention that appends output format suffix to original SVG filename during batch conversion.

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
            // Define input and output directories
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPdfs";

            // Ensure the output directory exists
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                // Extract the original file name without extension
                string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);

                // Build the output PDF path with format suffix
                string pdfPath = System.IO.Path.Combine(outputFolder, fileName + "_pdf.pdf");

                // Configure PDF save options with integer margins
                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(options.PageSetup.AnyPage.Size, new Margin(10, 10, 10, 10));

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