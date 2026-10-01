// Merge two Markdown documents while preserving heading hierarchy and inserting a separator comment.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath1 = "doc1.md";
            string inputPath2 = "doc2.md";
            string outputPath = "merged.md";

            // Create sample markdown files if they do not exist
            if (!File.Exists(inputPath1))
            {
                File.WriteAllText(inputPath1, "# Title 1\n\nContent of the first document.");
            }
            if (!File.Exists(inputPath2))
            {
                File.WriteAllText(inputPath2, "## Title 2\n\nContent of the second document.");
            }

            // Convert markdown files to HTML documents
            Aspose.Html.HTMLDocument doc1 = Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath1);
            Aspose.Html.HTMLDocument doc2 = Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath2);

            // Create a new HTML document to hold the merged content
            Aspose.Html.HTMLDocument mergedDoc = new Aspose.Html.HTMLDocument();

            // Append nodes from the first document
            for (Aspose.Html.Dom.Node node = doc1.Body.FirstChild; node != null; node = node.NextSibling)
            {
                mergedDoc.Body.AppendChild(node.CloneNode(true));
            }

            // Insert a separator comment
            Aspose.Html.Dom.Comment separator = mergedDoc.CreateComment(" Separator ");
            mergedDoc.Body.AppendChild(separator);

            // Append nodes from the second document
            for (Aspose.Html.Dom.Node node = doc2.Body.FirstChild; node != null; node = node.NextSibling)
            {
                mergedDoc.Body.AppendChild(node.CloneNode(true));
            }

            // Save the merged document as Markdown with desired features
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;
            mergedDoc.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}