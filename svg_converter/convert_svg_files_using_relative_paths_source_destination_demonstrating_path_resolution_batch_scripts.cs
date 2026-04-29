// Convert SVG files using relative paths for source and destination, demonstrating path resolution in batch scripts.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace SvgBatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Relative paths for input and output folders
                string inputFolder = "./input";
                string outputFolder = "./output";

                // Ensure the output folder exists
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Get all SVG files in the input folder
                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

                foreach (string svgPath in svgFiles)
                {
                    // Determine output PDF file name
                    string fileName = Path.GetFileNameWithoutExtension(svgPath);
                    string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                    // Create PDF save options with integer margins
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.PageSetup.AnyPage = new Page(
                        options.PageSetup.AnyPage.Size,
                        new Margin(10, 10, 10, 10) // left, top, right, bottom margins
                    );

                    // Convert SVG to PDF using relative paths
                    Converter.ConvertSVG(svgPath, options, pdfPath);
                }

                Console.WriteLine("Batch conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}