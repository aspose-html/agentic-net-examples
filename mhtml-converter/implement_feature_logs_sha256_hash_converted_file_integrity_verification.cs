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
            // Define input and output paths
            string inputMhtmlPath = "sample.mht";
            string outputDocxPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputMhtmlPath))
            {
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, Aspose.HTML!</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputMhtmlPath, mhtmlContent);
            }

            // Open the source MHTML as a stream
            using (FileStream inputStream = File.OpenRead(inputMhtmlPath))
            {
                // Set up save options for DOCX
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputDocxPath);
            }

            // Read the output file bytes
            byte[] outputBytes = File.ReadAllBytes(outputDocxPath);

            // Compute SHA-256 hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(outputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                // Print results
                Console.WriteLine($"Output file: {outputDocxPath}");
                Console.WriteLine($"SHA-256: {hashString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}