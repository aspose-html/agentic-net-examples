// Batch convert a directory of MHTML files to PDF, naming outputs based on original filenames.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "MhtmlFiles");
            System.IO.Directory.CreateDirectory(folderPath);
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = System.IO.Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            using (System.IO.FileStream stream = System.IO.File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = System.IO.Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                System.Console.WriteLine("Converted: " + System.IO.Path.GetFileName(mhtmlPath) + " -> " + System.IO.Path.GetFileName(pdfPath));
            }
        }

        if (mhtmlFiles.Length == 0)
        {
            System.Console.WriteLine("No MHTML files found in folder: " + folderPath);
        }
    }
}