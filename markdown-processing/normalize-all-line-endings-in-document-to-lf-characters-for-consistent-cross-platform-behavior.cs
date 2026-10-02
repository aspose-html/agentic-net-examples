// Normalize all line endings in the document to LF characters for consistent cross‑platform behavior.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with Windows line endings
            string htmlContent = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<title>Sample</title>\r\n</head>\r\n<body>\r\n<p>Hello, World!</p>\r\n</body>\r\n</html>";
            string baseUri = "about:blank";

            // Load HTML content into a document
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Save the document to a temporary file
            string tempPath = Path.GetTempFileName();
            document.Save(tempPath);

            // Read the saved file and normalize line endings to LF
            string normalized = File.ReadAllText(tempPath).Replace("\r\n", "\n");

            // Write the normalized content to the final output file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "normalized.html");
            File.WriteAllText(outputPath, normalized);

            // Clean up temporary file
            File.Delete(tempPath);

            Console.WriteLine($"Normalized HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}