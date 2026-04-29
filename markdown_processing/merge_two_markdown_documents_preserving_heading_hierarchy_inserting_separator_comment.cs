// Merge two Markdown documents while preserving heading hierarchy and inserting a separator comment.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath1 = "doc1.md";
            string markdownPath2 = "doc2.md";
            string outputPath = "merged.md";

            HTMLDocument doc1 = Converter.ConvertMarkdown(markdownPath1);
            HTMLDocument doc2 = Converter.ConvertMarkdown(markdownPath2);

            Comment separator = doc1.CreateComment("=== Separator ===");
            doc1.Body.AppendChild(separator);

            foreach (Node node in doc2.Body.ChildNodes)
            {
                Node imported = doc1.ImportNode(node, true);
                doc1.Body.AppendChild(imported);
            }

            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;
            Converter.ConvertHTML(doc1, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}