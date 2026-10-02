// Create a batch script that processes all MHTML files in a directory and outputs PDFs with timestamped names.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            Console.WriteLine($"Converted: {outputPath}");
        }
    }
}