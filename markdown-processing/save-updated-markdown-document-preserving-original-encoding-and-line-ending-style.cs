// Save the updated Markdown document preserving the original file encoding and line ending style.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "sample.md";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml, Encoding.UTF8);
            }

            // Detect original encoding (assumed UTF-8) and line ending style
            byte[] inputBytes = File.ReadAllBytes(inputPath);
            Encoding originalEncoding = Encoding.UTF8;
            string inputContent = originalEncoding.GetString(inputBytes);
            string lineEnding = inputContent.Contains("\r\n") ? "\r\n" : "\n";

            // Convert HTML to Markdown using Git preset
            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            // Read the generated Markdown, adjust line endings, and write back preserving encoding
            string markdown = File.ReadAllText(outputPath, originalEncoding);
            string normalized = markdown.Replace("\r\n", "\n").Replace("\n", lineEnding);
            File.WriteAllText(outputPath, normalized, originalEncoding);

            Console.WriteLine($"Conversion completed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}