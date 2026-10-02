// Update the text of an ATX heading while preserving its original number of hash symbols.

using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            // Update ATX heading text while preserving hash symbols
            string originalHeading = "## Old Heading";
            int hashCount = 0;
            while (hashCount < originalHeading.Length && originalHeading[hashCount] == '#')
                hashCount++;
            string newHeadingText = "New Heading";
            string updatedHeading = new string('#', hashCount) + " " + newHeadingText;
            Console.WriteLine("Updated heading: " + updatedHeading);

            // Prepare a minimal MHTML file
            string inputMhtmlPath = "sample.mhtml";
            string mhtmlContent = "From: <Saved by WebKit>\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1># Sample Heading</h1></body></html>\r\n------=_NextPart_000_0000--";
            File.WriteAllText(inputMhtmlPath, mhtmlContent);

            // Convert MHTML to DOCX
            string outputDocxPath = "output.docx";
            using (Stream inputStream = File.OpenRead(inputMhtmlPath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputDocxPath);
            }

            // Compute SHA-256 hash of the output file
            byte[] outputBytes = File.ReadAllBytes(outputDocxPath);
            string hashString;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(outputBytes);
                hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }

            // Print results
            Console.WriteLine("Output DOCX path: " + Path.GetFullPath(outputDocxPath));
            Console.WriteLine("SHA-256 hash: " + hashString);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}