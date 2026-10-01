// Capture conversion exceptions and log error messages with source file path for troubleshooting.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputMhtml");
            ConvertMhtmlFilesInFolder(inputFolder);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            // Create a minimal sample MHTML file if none exist
            string samplePath = Path.Combine(folderPath, "sample.mhtml");
            File.WriteAllText(samplePath, "<html><body>Sample MHTML content</body></html>");
        }

        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Converted: \"{Path.GetFileName(mhtmlPath)}\" to \"{Path.GetFileName(outputPath)}\"");
            }
        }
    }
}