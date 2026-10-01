// Batch convert a directory of MHTML files to PDF, naming outputs based on original filenames.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlSamples");
            EnsureSampleFolder(inputFolder);
            ConvertMhtmlFilesInFolder(inputFolder);
            Console.WriteLine("Note: Extracting text from the generated PDFs requires a separate PDF parsing library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void EnsureSampleFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string sampleFile = Path.Combine(folderPath, "sample.mhtml");
        if (!File.Exists(sampleFile))
        {
            // Minimal HTML content saved as .mhtml for demonstration purposes
            File.WriteAllText(sampleFile, "<html><body><h1>Sample MHTML</h1></body></html>");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            ConvertFile(mhtmlPath);
        }

        // Also handle .mht extension if present
        string[] mhtFiles = Directory.GetFiles(folderPath, "*.mht");
        foreach (string mhtmlPath in mhtFiles)
        {
            ConvertFile(mhtmlPath);
        }
    }

    static void ConvertFile(string mhtmlPath)
    {
        using (FileStream stream = File.OpenRead(mhtmlPath))
        {
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            Console.WriteLine($"Converted: {Path.GetFileName(mhtmlPath)} -> {Path.GetFileName(outputPath)}");
        }
    }
}