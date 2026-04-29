// Develop a Windows service that monitors a folder for new MHTML files and converts them to PDF.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    // Entry point of the console application
    static void Main(string[] args)
    {
        try
        {
            // Determine the folder to monitor (first argument or default)
            string folder = args.Length > 0 ? args[0] : "MhtmlFolder";
            ConvertMhtmlFilesInFolder(folder);
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Scans the specified folder for *.mhtml files and converts each to a PDF
    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder does not exist: {folderPath}");
            return;
        }

        // Get all MHTML files in the folder
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");

        foreach (string mhtmlPath in mhtmlFiles)
        {
            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                // Create default PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Build the output PDF file path (same name, .pdf extension)
                string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");

                // Perform the conversion
                Converter.ConvertMHTML(stream, options, pdfPath);

                // Log the successful conversion
                Console.WriteLine($"Converted: {pdfPath}");
            }
        }
    }
}