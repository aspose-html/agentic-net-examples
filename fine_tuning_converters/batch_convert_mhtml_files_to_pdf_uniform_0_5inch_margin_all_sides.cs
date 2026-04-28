// Batch convert a set of MHTML files to PDF, applying a uniform 0.5‑inch margin on all sides.

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
            // Input folder containing MHTML files
            string inputFolder = @"C:\InputMhtml";
            // Output folder for generated PDFs
            string outputFolder = @"C:\OutputPdf";

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all MHTML files in the input folder
            string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mhtml", SearchOption.TopDirectoryOnly);

            foreach (string mhtmlPath in mhtmlFiles)
            {
                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(mhtmlPath);
                string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Open MHTML file as a read stream
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    // Create PDF save options
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Define page size (A4) and uniform 0.5‑inch margins (36 points)
                    Page page = new Page(
                        new Size(595, 842),                     // Width and height in points (A4)
                        new Margin(36, 36, 36, 36)              // Top, Right, Bottom, Left margins
                    );
                    options.PageSetup.AnyPage = page;

                    // Convert MHTML stream to PDF with the specified options
                    Converter.ConvertMHTML(stream, options, pdfPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}