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
            string outputDir = Directory.GetCurrentDirectory();

            string sourcePath = Path.Combine(outputDir, "document.md");
            string markdownContent = @"
# Sample Document

This is a paragraph with a footnote reference.[^1]

Another paragraph with another footnote.[^2]

[^1]: This is the first footnote.
[^2]: This is the second footnote.
";
            File.WriteAllText(sourcePath, markdownContent);

            string savePath = Path.Combine(outputDir, "document-output.docx");

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            var footnoteSection = document.QuerySelector("section.footnotes") ??
                                  document.QuerySelector("div.footnotes") ??
                                  document.QuerySelector("ol.footnotes");

            if (footnoteSection != null)
            {
                var endnotesDiv = document.CreateElement("div");
                var heading = document.CreateElement("h2");
                heading.TextContent = "Endnotes";
                endnotesDiv.AppendChild(heading);
                endnotesDiv.AppendChild(footnoteSection.CloneNode(true));
                document.Body.AppendChild(endnotesDiv);
                footnoteSection.Remove();
            }

            DocSaveOptions options = new DocSaveOptions();
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}