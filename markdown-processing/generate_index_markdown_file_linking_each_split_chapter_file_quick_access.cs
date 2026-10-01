// Generate an index Markdown file linking to each split chapter file for quick access.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define output directory
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Sample chapter file names
            string[] chapters = { "chapter1.md", "chapter2.md", "chapter3.md" };

            // Create minimal chapter files
            foreach (string chapter in chapters)
            {
                string chapterPath = Path.Combine(outputDir, chapter);
                File.WriteAllText(chapterPath, $"# {Path.GetFileNameWithoutExtension(chapter)}\n\nContent of {chapter}.");
            }

            // Build HTML content for the index
            string htmlContent = "<h1>Index</h1><ul>";
            foreach (string chapter in chapters)
            {
                htmlContent += $"<li><a href=\"{chapter}\">{Path.GetFileNameWithoutExtension(chapter)}</a></li>";
            }
            htmlContent += "</ul>";

            // Configure Markdown save options
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            // Define output markdown file path
            string indexPath = Path.Combine(outputDir, "index.md");

            // Convert HTML to Markdown and save
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, indexPath);

            Console.WriteLine($"Index markdown file created at: {indexPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}