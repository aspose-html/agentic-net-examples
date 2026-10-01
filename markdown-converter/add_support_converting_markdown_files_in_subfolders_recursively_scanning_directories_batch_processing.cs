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

            // Ensure folders exist
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            string[] existingMd = Directory.GetFiles(inputFolder, "*.md", SearchOption.AllDirectories);
            if (existingMd.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                string sampleContent = "# Sample Markdown\r\n\r\nThis is a **test** markdown file.";
                File.WriteAllText(samplePath, sampleContent);
            }

            // Recursively process all markdown files
            foreach (string markdownPath in Directory.GetFiles(inputFolder, "*.md", SearchOption.AllDirectories))
            {
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(markdownPath) + ".html");
                Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, outputPath);
                Console.WriteLine($"Converted: {markdownPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}