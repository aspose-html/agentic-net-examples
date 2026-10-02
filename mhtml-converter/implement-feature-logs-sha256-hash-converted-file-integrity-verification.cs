// Implement a feature that logs the SHA‑256 hash of the converted file for integrity verification.

using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Sample MHTML Content</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }

            byte[] outputBytes = File.ReadAllBytes(outputPath);
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(outputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                Console.WriteLine($"Output file: {outputPath}");
                Console.WriteLine($"SHA-256: {hashString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}