// Specify output file naming conventions based on source URL host and path segments.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Source URL of the HTML document
            string sourceUrl = "https://example.com/path/to/page.html";

            // Parse the URL to extract host and path segments
            Uri uri = new Uri(sourceUrl);
            string hostPart = uri.Host.Replace(".", "_"); // replace dots to avoid filesystem issues

            // Clean and join path segments
            string[] rawSegments = uri.Segments;
            for (int i = 0; i < rawSegments.Length; i++)
            {
                rawSegments[i] = rawSegments[i].Trim('/').Replace(".", "_");
            }
            string pathPart = string.Join("_", rawSegments);

            // Build output file name based on host and path
            string outputFileName = $"{hostPart}_{pathPart}.html";

            // Determine full output path (current directory)
            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, outputFileName);

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(sourceUrl);

            // Save the document using the generated file name
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}