// Add support for converting Markdown files located in subfolders by recursively scanning directories during batch processing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputHtml";

            // Ensure directories exist
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file in a subfolder
            string subFolder = Path.Combine(inputFolder, "SubFolder");
            Directory.CreateDirectory(subFolder);
            string sampleMarkdownPath = Path.Combine(subFolder, "sample.md");
            if (!File.Exists(sampleMarkdownPath))
            {
                string markdownContent = "# Sample Markdown\r\nThis is a *test* markdown file.";
                File.WriteAllText(sampleMarkdownPath, markdownContent);
            }

            // Recursively process all markdown files
            foreach (string markdownPath in Directory.GetFiles(inputFolder, "*.md", SearchOption.AllDirectories))
            {
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(markdownPath) + ".html");
                Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, outputPath);
                Console.WriteLine($"Converted '{markdownPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}