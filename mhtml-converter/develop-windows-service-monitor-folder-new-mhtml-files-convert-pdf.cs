// Develop a Windows service that monitors a folder for new MHTML files and converts them to PDF.

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
                Directory.CreateDirectory(folderPath);

            // Create a sample MHTML file if the folder is empty
            if (Directory.GetFiles(folderPath, "*.mhtml").Length == 0)
            {
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "Dummy MHTML content");
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
        foreach (string mhtmlPath in Directory.GetFiles(folderPath, "*.mhtml"))
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Converted: {Path.GetFileName(mhtmlPath)} -> {Path.GetFileName(outputPath)}");
            }
        }

        Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library.");
    }
}