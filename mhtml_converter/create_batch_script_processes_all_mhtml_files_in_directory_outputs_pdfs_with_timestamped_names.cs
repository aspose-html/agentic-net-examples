// Create a batch script that processes all MHTML files in a directory and outputs PDFs with timestamped names.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MhtmlToPdfBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string folder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
                ConvertMhtmlFilesInFolder(folder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertMhtmlFilesInFolder(string folderPath)
        {
            // Scan the folder for MHTML files
            string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
            foreach (string mhtmlPath in mhtmlFiles)
            {
                // Open each MHTML file as a stream
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    // Create PDF save options
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Build the base PDF output path
                    string basePdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");

                    // Append a timestamp to the file name
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string dir = Path.GetDirectoryName(basePdfPath);
                    string nameWithoutExt = Path.GetFileNameWithoutExtension(basePdfPath);
                    string outputPath = Path.Combine(dir, $"{nameWithoutExt}_{timestamp}.pdf");

                    // Convert MHTML to PDF
                    Converter.ConvertMHTML(stream, options, outputPath);

                    Console.WriteLine($"Converted: {mhtmlPath} -> {outputPath}");
                }
            }
        }
    }
}