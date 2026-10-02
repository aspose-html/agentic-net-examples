// Merge two Markdown documents while preserving heading hierarchy and inserting a separator comment.

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
            // Prepare sample markdown files
            string doc1Path = "doc1.md";
            string doc2Path = "doc2.md";
            string mergedPath = "merged.md";

            File.WriteAllText(doc1Path, "# Document 1\n\nThis is the first document.\n");
            File.WriteAllText(doc2Path, "# Document 2\n\nThis is the second document.\n");

            // Load markdown files into HTML documents
            HTMLDocument doc1 = Aspose.Html.Converters.Converter.ConvertMarkdown(doc1Path);
            HTMLDocument doc2 = Aspose.Html.Converters.Converter.ConvertMarkdown(doc2Path);

            // Create a new document to hold the merged content
            HTMLDocument mergedDoc = new HTMLDocument();

            // Append content of the first document
            mergedDoc.Body.AppendChild(mergedDoc.ImportNode(doc1.Body, true));

            // Insert a separator comment
            var separatorComment = mergedDoc.CreateComment(" Separator ");
            mergedDoc.Body.AppendChild(separatorComment);

            // Append content of the second document
            mergedDoc.Body.AppendChild(mergedDoc.ImportNode(doc2.Body, true));

            // Save the merged document as Markdown
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;
            mergedDoc.Save(mergedPath, options);

            Console.WriteLine("Merged markdown saved to: " + Path.GetFullPath(mergedPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}