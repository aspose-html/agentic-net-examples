// Append a timestamp to the saved file name to avoid overwriting existing files.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define output directory and ensure it exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Generate a timestamped file name to avoid overwriting
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputPath = Path.Combine(outputDir, $"document_{timestamp}.html");

            // Create an empty HTML document, add a text node, and save it
            using (HTMLDocument document = new HTMLDocument())
            {
                document.Body.AppendChild(document.CreateTextNode("Hello, World!"));
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