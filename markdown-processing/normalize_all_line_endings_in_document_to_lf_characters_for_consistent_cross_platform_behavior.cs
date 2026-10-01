// Normalize all line endings in the document to LF characters for consistent cross‑platform behavior.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with Windows line endings
            string htmlContent = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<title>Test</title>\r\n</head>\r\n<body>\r\n<p>Hello World</p>\r\n</body>\r\n</html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Save the document to a temporary file in HTML format
            string tempPath = Path.GetTempFileName();
            document.Save(tempPath);

            // Read the saved content and normalize line endings to LF
            string fileContent = File.ReadAllText(tempPath);
            string normalizedContent = fileContent.Replace("\r\n", "\n");

            // Define the final output path
            string outputPath = Path.Combine(Path.GetTempPath(), "normalized.html");
            File.WriteAllText(outputPath, normalizedContent);

            // Clean up the temporary file
            File.Delete(tempPath);

            Console.WriteLine($"Normalized HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}