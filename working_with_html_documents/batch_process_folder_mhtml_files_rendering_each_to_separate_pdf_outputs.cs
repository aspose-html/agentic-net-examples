// Batch process a folder of MHTML files, rendering each to separate PDF outputs.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MhtmlBatchConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string folderPath = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
                ConvertMhtmlFilesInFolder(folderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertMhtmlFilesInFolder(string folderPath)
        {
            // Get all MHTML files in the specified folder
            string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");

            foreach (string mhtmlPath in mhtmlFiles)
            {
                // Open the MHTML file as a read‑only stream
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    // Default PDF save options
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Build the output PDF path (same name, .pdf extension)
                    string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");

                    // Perform the conversion
                    Converter.ConvertMHTML(stream, options, pdfPath);

                    Console.WriteLine($"Converted: {pdfPath}");
                }
            }
        }
    }
}