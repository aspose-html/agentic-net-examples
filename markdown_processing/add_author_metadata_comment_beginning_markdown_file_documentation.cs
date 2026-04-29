// Add an author metadata comment at the beginning of the Markdown file for documentation purposes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Directory.GetCurrentDirectory();
            string sourcePath = Path.Combine(outputDir, "document.md");
            string markdownContent = "<!-- Author: John Doe -->\n# Sample Document\nThis is a sample markdown.";
            File.WriteAllText(sourcePath, markdownContent);
            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
            string savePath = Path.Combine(outputDir, "document-output.docx");
            Converter.ConvertHTML(document, new DocSaveOptions(), savePath);
            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}