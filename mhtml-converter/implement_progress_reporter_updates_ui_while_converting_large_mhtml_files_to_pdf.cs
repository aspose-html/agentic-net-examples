// Implement a progress reporter that updates the UI while converting large MHTML files to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MhtmlFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                // Create a minimal sample MHTML file if none exist
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                if (!File.Exists(samplePath))
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
                    File.WriteAllText(samplePath, mhtmlContent);
                }
            }

            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        int total = mhtmlFiles.Length;
        if (total == 0)
        {
            Console.WriteLine("No MHTML files found to convert.");
            return;
        }

        for (int i = 0; i < total; i++)
        {
            string mhtmlPath = mhtmlFiles[i];
            string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");

            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
            }

            Console.WriteLine($"Converted {i + 1}/{total}: {Path.GetFileName(mhtmlPath)} -> {Path.GetFileName(pdfPath)}");
        }
    }
}