// Enable compression of the HTML output to reduce file size for faster transmission.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string tempHtmlPath = "temp.html";
            string compressedOutputPath = "output.html.gz";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputHtmlPath))
            {
                // Save the document to a temporary HTML file
                document.Save(tempHtmlPath);
            }

            // Compress the temporary HTML file into GZIP format
            using (FileStream originalFile = File.OpenRead(tempHtmlPath))
            using (FileStream compressedFile = File.Create(compressedOutputPath))
            using (GZipStream compressionStream = new GZipStream(compressedFile, CompressionLevel.Optimal))
            {
                originalFile.CopyTo(compressionStream);
            }

            // Delete the temporary HTML file
            File.Delete(tempHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}