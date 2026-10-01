// Export the entire MarkdownSyntaxTree to an XML file for archival and version control purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            string sourcePath = Path.Combine(outputDir, "sample.md");
            string markdownContent = "# Sample Title\n\nThis is a sample markdown document.";
            File.WriteAllText(sourcePath, markdownContent);

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                string savePath = Path.Combine(outputDir, "markdown_syntax.xml");
                document.Save(savePath, new Aspose.Html.Saving.HTMLSaveOptions());
                Console.WriteLine($"Markdown syntax tree exported to XML at: {savePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}