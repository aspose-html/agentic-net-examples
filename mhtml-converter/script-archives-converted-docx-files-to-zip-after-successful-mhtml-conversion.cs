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
            // Prepare directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample MHTML file (minimal content)
            string sampleMhtmlPath = Path.Combine(inputDir, "sample.mht");
            if (!File.Exists(sampleMhtmlPath))
            {
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(sampleMhtmlPath, mhtmlContent);
            }

            // Convert each MHTML file to DOCX
            string[] mhtmlFiles = Directory.GetFiles(inputDir, "*.mht");
            foreach (string mhtmlFile in mhtmlFiles)
            {
                string docxFileName = Path.GetFileNameWithoutExtension(mhtmlFile) + ".docx";
                string docxPath = Path.Combine(outputDir, docxFileName);

                using (FileStream inputStream = File.OpenRead(mhtmlFile))
                {
                    DocSaveOptions saveOptions = new DocSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, docxPath);
                }
            }

            // Archive all converted DOCX files into a zip
            string zipPath = Path.Combine(Directory.GetCurrentDirectory(), "ConvertedDocs.zip");
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
            {
                string[] docxFiles = Directory.GetFiles(outputDir, "*.docx");
                foreach (string docxFile in docxFiles)
                {
                    string entryName = Path.GetFileName(docxFile);
                    ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = File.OpenRead(docxFile))
                    {
                        fileStream.CopyTo(entryStream);
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