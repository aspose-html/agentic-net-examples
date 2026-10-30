// Write a script that archives original MHTML files after successful conversion to DOCX.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputMhtml";
            string outputDir = "OutputDocx";
            string archiveDir = "ArchiveMhtml";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(archiveDir);

            string[] mhtmlFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string mhtmlPath in mhtmlFiles)
            {
                string extension = Path.GetExtension(mhtmlPath).ToLowerInvariant();
                if (extension != ".mht" && extension != ".mhtml")
                {
                    continue;
                }

                try
                {
                    using (Stream stream = File.OpenRead(mhtmlPath))
                    {
                        var saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(mhtmlPath) + ".docx");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
                    }

                    string archivePath = Path.Combine(archiveDir, Path.GetFileName(mhtmlPath));
                    File.Move(mhtmlPath, archivePath);
                    Console.WriteLine($"Converted and archived: {Path.GetFileName(mhtmlPath)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{Path.GetFileName(mhtmlPath)}': {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}