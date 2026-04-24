// Convert a list of EPUB file paths to DOCX using a reusable method that accepts save options.

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
            // List of EPUB files to convert
            string[] epubFiles = new string[]
            {
                @"C:\Input\book1.epub",
                @"C:\Input\book2.epub",
                @"C:\Input\book3.epub"
            };

            // Directory where DOCX files will be saved
            string outputDir = @"C:\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Create default DOCX save options (can be customized if needed)
            DocSaveOptions options = new DocSaveOptions();

            // Convert each EPUB file
            foreach (string epubPath in epubFiles)
            {
                // Build the output DOCX file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                string docxPath = Path.Combine(outputDir, fileNameWithoutExt + ".docx");

                ConvertEpubToDocx(epubPath, docxPath, options);
                Console.WriteLine($"Converted '{epubPath}' to '{docxPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Reusable method that converts a single EPUB file to DOCX using provided save options
    static void ConvertEpubToDocx(string sourcePath, string outputPath, DocSaveOptions options)
    {
        // Open the EPUB file as a read‑only stream
        using (Stream stream = File.OpenRead(sourcePath))
        {
            // Perform the conversion
            Converter.ConvertEPUB(stream, options, outputPath);
        }
    }
}