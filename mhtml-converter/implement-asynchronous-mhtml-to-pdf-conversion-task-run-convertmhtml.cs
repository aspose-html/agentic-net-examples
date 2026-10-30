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
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                // Create a minimal sample MHTML file
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "<!-- Sample MHTML content -->");
            }

            await ConvertMhtmlFilesInFolder(folderPath);
            Console.WriteLine("Note: Extracting text from the generated PDFs requires a separate PDF parsing library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in files)
        {
            await Task.Run(() =>
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                    Console.WriteLine($"Converted: {pdfPath}");
                }
            });
        }
    }
}