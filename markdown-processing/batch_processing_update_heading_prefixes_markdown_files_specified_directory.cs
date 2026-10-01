// Perform batch processing to update heading prefixes across all Markdown files in a specified directory.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputMarkdown";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputFolder, "*.md").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Heading 1\nSome content.\n## Heading 2\nMore content.");
            }

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                string markdown = File.ReadAllText(mdPath);
                // Example transformation: increase heading level by one '#'
                string updated = Regex.Replace(markdown, @"^(#+)\s", m => new string('#', m.Groups[1].Value.Length + 1) + " ");
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(mdPath));
                File.WriteAllText(outputPath, updated);
            }

            // Demonstrate basic Aspose.HTML usage
            string htmlContent = "<html><body><p>Sample</p></body></html>";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            doc.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}