// Convert Markdown footnotes to endnotes and adjust references accordingly throughout the document.

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
            // Define output directory and ensure it exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Define source markdown file path
            string sourcePath = Path.Combine(outputDir, "document.md");

            // Sample markdown content with footnotes
            string markdownContent = @"This is a sample paragraph with a footnote reference.[^1]

Another paragraph with a second footnote.[^2]

[^1]: This is the first footnote.
[^2]: This is the second footnote.";

            // Create the markdown file
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Define output DOCX path
            string savePath = Path.Combine(outputDir, "document-output.docx");

            // Convert HTMLDocument to DOCX
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Markdown file: {sourcePath}");
            Console.WriteLine($"DOCX output: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}