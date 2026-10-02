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
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
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
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        if (mhtmlFiles.Length == 0)
        {
            Console.WriteLine("No MHTML files found to convert.");
            return;
        }

        foreach (string mhtmlPath in mhtmlFiles)
        {
            string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            try
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                }

                File.Delete(mhtmlPath);
                Console.WriteLine($"Converted: {pdfPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert '{mhtmlPath}': {ex.Message}");
            }
        }
    }
}