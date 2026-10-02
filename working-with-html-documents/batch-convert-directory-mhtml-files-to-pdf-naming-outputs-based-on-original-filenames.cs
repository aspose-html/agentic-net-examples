// Batch convert a directory of MHTML files to PDF, naming outputs based on original filenames.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "MhtmlFiles";
            ConvertMhtmlFilesInFolder(inputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!System.IO.Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder does not exist: {folderPath}");
            return;
        }

        foreach (string mhtmlPath in System.IO.Directory.GetFiles(folderPath, "*.mhtml"))
        {
            try
            {
                using (System.IO.FileStream stream = System.IO.File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string outputPath = System.IO.Path.ChangeExtension(mhtmlPath, ".pdf");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Converted: {System.IO.Path.GetFileName(mhtmlPath)} -> {System.IO.Path.GetFileName(outputPath)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting {mhtmlPath}: {ex.Message}");
            }
        }
    }
}