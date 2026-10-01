// Implement a feature that automatically deletes source MHTML files after successful conversion to PDF to save space.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = "MhtmlFiles";
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
            Console.WriteLine($"Folder not found: {folderPath}");
            return;
        }

        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                Console.WriteLine($"Converted: {Path.GetFileName(pdfPath)}");
            }

            try
            {
                File.Delete(mhtmlPath);
                Console.WriteLine($"Deleted source MHTML: {Path.GetFileName(mhtmlPath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {Path.GetFileName(mhtmlPath)}: {ex.Message}");
            }
        }

        Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library if such a library is not available in the current project.");
    }
}