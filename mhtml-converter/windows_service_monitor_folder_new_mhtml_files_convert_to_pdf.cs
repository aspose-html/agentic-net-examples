// Develop a Windows service that monitors a folder for new MHTML files and converts them to PDF.

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
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlFiles");
            // Ensure the folder exists; create a sample file if needed
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                // Create a minimal sample MHTML file for demonstration
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "MIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Sample MHTML</h1></body></html>\r\n------=_NextPart_000_0000--");
            }

            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder does not exist: {folderPath}");
            return;
        }

        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Converted: {outputPath}");
            }
        }
    }
}