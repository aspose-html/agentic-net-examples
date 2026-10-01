// Write code to convert MHTML to XPS and then extract the XPS package contents for analysis.

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
            // Define paths
            string currentDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(currentDir, "sample.mht");
            string outputPath = Path.Combine(currentDir, "output.xps");
            string extractDir = Path.Combine(currentDir, "xps_contents");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Mon, 1 Jan 2020 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
                Console.WriteLine($"Created sample MHTML file at: {inputPath}");
            }

            // Convert MHTML to XPS
            using (FileStream mhtmlStream = File.OpenRead(inputPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, options, outputPath);
            }
            Console.WriteLine($"MHTML converted to XPS at: {outputPath}");

            // Extract XPS package contents
            if (!Directory.Exists(extractDir))
            {
                Directory.CreateDirectory(extractDir);
            }

            using (FileStream xpsFileStream = File.OpenRead(outputPath))
            using (ZipArchive zip = new ZipArchive(xpsFileStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string destinationPath = Path.Combine(extractDir, entry.FullName);
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    using (Stream entryStream = entry.Open())
                    using (FileStream destStream = File.Create(destinationPath))
                    {
                        entryStream.CopyTo(destStream);
                    }

                    Console.WriteLine($"Extracted: {entry.FullName} ({entry.Length} bytes)");
                }
            }

            Console.WriteLine($"Extraction completed. Files are located in: {extractDir}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}