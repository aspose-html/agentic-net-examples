// Batch convert a collection of SVG files to PDF, preserving vector fidelity for printing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace SvgBatchToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output folders
                string inputFolder = @"C:\SvgInput";
                string outputFolder = @"C:\PdfOutput";

                // Ensure the output folder exists
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Get all SVG files in the input folder
                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

                foreach (string svgPath in svgFiles)
                {
                    // Determine output PDF file path
                    string fileName = Path.GetFileNameWithoutExtension(svgPath);
                    string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                    // Configure PDF save options with integer margin values
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.PageSetup.AnyPage = new Page(
                        options.PageSetup.AnyPage.Size,
                        new Margin(0, 0, 0, 0) // integer margins (left, top, right, bottom)
                    );

                    // Convert SVG to PDF
                    Converter.ConvertSVG(svgPath, options, pdfPath);
                }

                Console.WriteLine("Batch conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
    }
}