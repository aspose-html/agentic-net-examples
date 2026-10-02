// Convert all uppercase heading texts to title case while preserving their hash level markers.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputMhtmlPath = "sample.mht";
            string outputDocxPath = "output.docx";

            // Create a minimal MHTML file
            string mhtmlContent = "From: <test@example.com>\nSubject: Test\n\n<html><body>Hello, Aspose!</body></html>";
            File.WriteAllText(inputMhtmlPath, mhtmlContent);

            // Open the MHTML file as a stream
            using (Stream inputStream = File.OpenRead(inputMhtmlPath))
            {
                // Set DOCX save options
                DocSaveOptions options = new DocSaveOptions();

                // Convert MHTML to DOCX
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputDocxPath);
            }

            // Compute SHA-256 hash of the generated DOCX file
            byte[] fileBytes = File.ReadAllBytes(outputDocxPath);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fileBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                // Print results
                Console.WriteLine("Output DOCX Path: " + Path.GetFullPath(outputDocxPath));
                Console.WriteLine("SHA-256 Hash: " + hash);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}