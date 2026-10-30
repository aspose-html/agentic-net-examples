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
            // Define input MHTML files (hard‑coded for the example)
            string[] mhtmlFiles = new string[]
            {
                "sample1.mhtml",
                "sample2.mhtml"
            };

            // Ensure output directory exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Path for the resulting zip archive
            string zipPath = Path.Combine(Directory.GetCurrentDirectory(), "ConvertedDocs.zip");

            // Create (or overwrite) the zip archive
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create))
            {
                foreach (string mhtmlPath in mhtmlFiles)
                {
                    if (!File.Exists(mhtmlPath))
                    {
                        Console.WriteLine($"Input file not found: {mhtmlPath}");
                        continue;
                    }

                    // Prepare output DOCX path
                    string docxFileName = Path.GetFileNameWithoutExtension(mhtmlPath) + ".docx";
                    string docxPath = Path.Combine(outputDir, docxFileName);

                    // Convert MHTML to DOCX
                    using (FileStream inputStream = File.OpenRead(mhtmlPath))
                    {
                        DocSaveOptions saveOptions = new DocSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, docxPath);
                    }

                    // Add the converted DOCX to the zip archive
                    zip.CreateEntryFromFile(docxPath, docxFileName);
                    Console.WriteLine($"Converted and archived: {docxFileName}");
                }
            }

            Console.WriteLine($"All conversions completed. Archive created at: {zipPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}