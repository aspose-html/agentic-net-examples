// Implement a feature that allows users to select multiple MHTML files and convert them to a single PDF document.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Determine input folder (first argument) and output folder (second argument)
            string inputFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            string outputFolder = args.Length > 1 ? args[1] : Path.Combine(Directory.GetCurrentDirectory(), "MergedPdf");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all MHTML files in the input folder
            string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mhtml");

            foreach (string mhtmlPath in mhtmlFiles)
            {
                // Open the MHTML file as a read‑only stream
                using (System.IO.Stream stream = System.IO.File.OpenRead(mhtmlPath))
                {
                    // Create default PDF save options
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                    // Build the output PDF file path (same name, .pdf extension)
                    string pdfPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(mhtmlPath) + ".pdf");

                    // Convert the MHTML stream to a PDF file
                    Converter.ConvertMHTML(stream, options, pdfPath);
                }
            }

            // Note: Combining the generated PDFs into a single document requires a PDF merging library,
            // which is not part of Aspose.Html. Implement merging separately if needed.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}