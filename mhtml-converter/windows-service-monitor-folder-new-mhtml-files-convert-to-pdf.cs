// Develop a Windows service that monitors a folder for new MHTML files and converts them to PDF.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "MhtmlInput";
            Directory.CreateDirectory(inputFolder);
            ConvertMhtmlFilesInFolder(inputFolder);
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
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Converted: {outputPath}");
            }
        }
    }
}