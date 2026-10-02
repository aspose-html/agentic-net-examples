// Generate an index Markdown file linking to each split chapter file for quick access.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Define chapter HTML contents
            string[] htmlChapters = new string[]
            {
                "<h1>Chapter 1</h1><p>Content of chapter 1.</p>",
                "<h1>Chapter 2</h1><p>Content of chapter 2.</p>",
                "<h1>Chapter 3</h1><p>Content of chapter 3.</p>"
            };

            string[] markdownFiles = new string[htmlChapters.Length];

            // Convert each HTML chapter to Markdown using Aspose.HTML
            for (int i = 0; i < htmlChapters.Length; i++)
            {
                string markdownFileName = $"chapter{i + 1}.md";
                string markdownPath = Path.Combine(outputDir, markdownFileName);
                markdownFiles[i] = markdownFileName;

                MarkdownSaveOptions options = new MarkdownSaveOptions();
                options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;

                Aspose.Html.Converters.Converter.ConvertHTML(htmlChapters[i], options, markdownPath);
            }

            // Build index markdown linking to each chapter file
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# Index");
            sb.AppendLine();
            foreach (string fileName in markdownFiles)
            {
                sb.AppendLine($"- [{fileName}]({fileName})");
            }

            string indexPath = Path.Combine(outputDir, "index.md");
            File.WriteAllText(indexPath, sb.ToString());

            Console.WriteLine($"Index file created at: {indexPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}