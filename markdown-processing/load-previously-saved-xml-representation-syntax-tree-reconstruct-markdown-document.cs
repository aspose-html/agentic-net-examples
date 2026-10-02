// Load a previously saved XML representation of a syntax tree and reconstruct the Markdown document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "syntaxTree.xml";
            string markdownContent = "# Sample Document\n\nThis is a reconstructed markdown from XML syntax tree.";
            File.WriteAllText(sourcePath, markdownContent);

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            string outputPath = "reconstructed.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Reconstruction completed. Markdown saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}