// Implement asynchronous conversion of MHTML to PDF using Task.Run and Converter.ConvertMHTML method.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlSamples");
            // Ensure the folder exists; create a sample MHTML file if none exist
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Create a minimal sample MHTML file if the folder is empty
            string[] existingFiles = Directory.GetFiles(folderPath, "*.mhtml");
            if (existingFiles.Length == 0)
            {
                string sampleMhtmlPath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(sampleMhtmlPath, "From: <test@example.com>\r\nSubject: Sample\r\n\r\n<html><body><h1>Sample MHTML</h1></body></html>");
            }

            await ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            await Task.Run(() =>
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                    Console.WriteLine($"Converted: {Path.GetFileName(mhtmlPath)} -> {Path.GetFileName(pdfPath)}");
                }
            });
        }

        Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library.");
    }
}