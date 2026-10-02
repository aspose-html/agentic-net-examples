// Apply a custom Markdown header template via MarkdownSaveOptions.Template to format document titles uniformly.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.md";
            string outputPath = "output.md";

            // Create a simple markdown file
            string markdownContent = "# Sample Title\n\nThis is a sample markdown document.";
            File.WriteAllText(sourcePath, markdownContent, Encoding.UTF8);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Save the document as markdown using MarkdownSaveOptions
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            document.Save(outputPath, options);

            // Post-process the saved markdown to apply a custom header template
            string savedMarkdown = File.ReadAllText(outputPath, Encoding.UTF8);
            string[] lines = savedMarkdown.Split(new[] { '\n' }, 2);
            if (lines.Length > 0 && lines[0].StartsWith("#"))
            {
                string originalTitle = lines[0].TrimStart('#').Trim();
                string customHeader = "## Custom Header: " + originalTitle;
                string rest = lines.Length > 1 ? lines[1] : string.Empty;
                savedMarkdown = customHeader + "\n\n" + rest;
                File.WriteAllText(outputPath, savedMarkdown, Encoding.UTF8);
            }

            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
            Console.WriteLine("Final Markdown content:");
            Console.WriteLine(savedMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}