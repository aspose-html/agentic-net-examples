// Implement batch conversion of multiple MHTML files to PDF using a foreach loop and Converter.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Specify the folder containing MHTML files
            string inputFolder = @"C:\MhtmlFiles";
            ConvertMhtmlFilesInFolder(inputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        // Scan the folder for *.mhtml files
        foreach (string mhtmlPath in Directory.GetFiles(folderPath, "*.mhtml"))
        {
            // Open each MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                // Create PDF save options with default settings
                PdfSaveOptions options = new PdfSaveOptions();

                // Build the output PDF file path
                string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");

                // Perform the conversion
                Converter.ConvertMHTML(stream, options, pdfPath);

                Console.WriteLine($"Converted: {mhtmlPath} -> {pdfPath}");
            }
        }
    }
}