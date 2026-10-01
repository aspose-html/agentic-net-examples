// Specify output file naming conventions based on source URL host and path segments.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Source URL
            string sourceUrl = "https://example.com/path/to/resource.html";

            // Parse URL to extract host and path segments
            Uri uri = new Uri(sourceUrl);
            string host = uri.Host.Replace(".", "_"); // replace dots to avoid filesystem issues
            string[] segments = uri.AbsolutePath.Trim('/').Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string pathPart = string.Join("_", segments);
            // Build output file name
            string fileName = string.IsNullOrEmpty(pathPart) ? $"{host}.html" : $"{host}_{pathPart}.html";

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, fileName);

            // Load HTML document from the URL
            using (var document = new Aspose.Html.HTMLDocument(sourceUrl, Directory.GetCurrentDirectory()))
            {
                // Save the document using the generated file name
                document.Save(outputPath);
            }

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}