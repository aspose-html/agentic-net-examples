// Implement a feature that automatically deletes source MHTML files after successful conversion to PDF to save space.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string folderPath = "MhtmlFiles";
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!System.IO.Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder not found: {folderPath}");
            return;
        }

        string[] mhtmlFiles = System.IO.Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            try
            {
                using (System.IO.Stream stream = System.IO.File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string outputPath = System.IO.Path.ChangeExtension(mhtmlPath, ".pdf");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Converted: {outputPath}");
                }

                System.IO.File.Delete(mhtmlPath);
                Console.WriteLine($"Deleted source file: {mhtmlPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert {mhtmlPath}: {ex.Message}");
            }
        }
    }
}