// Add an author metadata comment at the beginning of the Markdown file for documentation purposes.

// Author: John Doe
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

            // Define source markdown file path
            string sourcePath = Path.Combine(outputDir, "document.md");

            // Create markdown content with author metadata comment
            string markdownContent = "<!-- Author: John Doe -->\n# Sample Document\nThis is a sample markdown file.";
            File.WriteAllText(sourcePath, markdownContent);

            // Define output DOCX file path
            string savePath = Path.Combine(outputDir, "document-output.docx");

            // Convert Markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Convert HTMLDocument to DOCX
            Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.DocSaveOptions(), savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}