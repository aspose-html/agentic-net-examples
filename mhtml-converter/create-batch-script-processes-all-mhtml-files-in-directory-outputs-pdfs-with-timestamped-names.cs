// Create a batch script that processes all MHTML files in a directory and outputs PDFs with timestamped names.

using System;
using System.IO;

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
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder does not exist: {folderPath}");
            return;
        }

        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            try
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();

                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string outputFileName = $"{Path.GetFileNameWithoutExtension(mhtmlPath)}_{timestamp}.pdf";
                    string outputPath = Path.Combine(Path.GetDirectoryName(mhtmlPath) ?? folderPath, outputFileName);

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Converted: {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert '{mhtmlPath}': {ex.Message}");
            }
        }
    }
}