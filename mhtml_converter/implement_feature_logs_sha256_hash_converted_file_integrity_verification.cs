// Implement a feature that logs the SHA‑256 hash of the converted file for integrity verification.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MhtmlToDocxWithHash
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output file paths
                string inputPath = "input.mhtml";
                string outputPath = "output.docx";

                // Open the source MHTML file as a stream
                using (Stream inputStream = File.OpenRead(inputPath))
                {
                    // Create conversion options for DOCX output
                    DocSaveOptions options = new DocSaveOptions();

                    // Perform conversion from MHTML stream to DOCX file
                    Converter.ConvertMHTML(inputStream, options, outputPath);
                }

                // Read the resulting DOCX file bytes
                byte[] outputBytes = File.ReadAllBytes(outputPath);

                // Compute SHA-256 hash of the output file
                string hash;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(outputBytes);
                    hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                }

                // Output the file path and its SHA-256 hash
                Console.WriteLine($"Output file: {outputPath}");
                Console.WriteLine($"SHA-256: {hash}");
            }
            catch (Exception ex)
            {
                // Print any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}