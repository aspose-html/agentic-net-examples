// Create a batch script that processes all MHTML files in a directory and outputs PDFs with timestamped names.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = "MhtmlFiles";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputFileName = Path.GetFileNameWithoutExtension(mhtmlPath) + "_" + timestamp + ".pdf";
                string outputPath = Path.Combine(folderPath, outputFileName);

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Converted: {outputFileName}");
            }
        }
    }
}