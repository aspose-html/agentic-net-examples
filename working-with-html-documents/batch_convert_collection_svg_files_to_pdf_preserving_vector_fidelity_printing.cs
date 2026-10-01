// Batch convert a collection of SVG files to PDF, preserving vector fidelity for printing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = "input_svgs";
            string outputFolder = "output_pdfs";

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

                // Create PDF save options with integer margins
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    options.PageSetup.AnyPage.Size,
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20));

                // Convert SVG to PDF
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}