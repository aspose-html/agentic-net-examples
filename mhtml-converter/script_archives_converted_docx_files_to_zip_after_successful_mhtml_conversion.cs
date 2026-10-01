// Write a script that archives converted DOCX files to a zip archive after successful MHTML conversion.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "OutputDocs");
            string zipPath = Path.Combine(baseDir, "ConvertedDocs.zip");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample MHTML file if none exist
            string[] existingMhtml = Directory.GetFiles(inputDir, "*.mht");
            if (existingMhtml.Length == 0)
            {
                string sampleMhtmlPath = Path.Combine(inputDir, "sample.mht");
                string sampleContent = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(sampleMhtmlPath, sampleContent);
            }

            // Convert each MHTML to DOCX
            foreach (string mhtmlFile in Directory.GetFiles(inputDir, "*.mht"))
            {
                using (FileStream inputStream = File.OpenRead(mhtmlFile))
                {
                    DocSaveOptions saveOptions = new DocSaveOptions();
                    string outputDocxPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(mhtmlFile) + ".docx");
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, outputDocxPath);
                }
            }

            // Create ZIP archive of converted DOCX files
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (string docxFile in Directory.GetFiles(outputDir, "*.docx"))
                    {
                        archive.CreateEntryFromFile(docxFile, Path.GetFileName(docxFile));
                    }
                }
            }

            Console.WriteLine("Conversion and archiving completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}