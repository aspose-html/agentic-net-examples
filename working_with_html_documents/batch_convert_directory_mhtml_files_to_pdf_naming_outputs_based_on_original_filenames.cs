// Batch convert a directory of MHTML files to PDF, naming outputs based on original filenames.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = "C:\\MhtmlFiles";
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
                PdfSaveOptions options = new PdfSaveOptions();
                string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine(outputPath);
            }
        }
    }
}