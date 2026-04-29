// Load multiple Markdown documents from a list and merge them into a single HTML output file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string[] markdownPaths = { "doc1.md", "doc2.md", "doc3.md" };
            string outputPath = "merged.html";

            Aspose.Html.HTMLDocument finalDocument = null;

            foreach (string path in markdownPaths)
            {
                string markdownContent = File.ReadAllText(path);
                var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent));
                Aspose.Html.HTMLDocument doc = Converter.ConvertMarkdown(stream, "");

                if (finalDocument == null)
                {
                    finalDocument = doc;
                }
                else
                {
                    var finalBody = finalDocument.QuerySelector("body");
                    var docBody = doc.QuerySelector("body");
                    if (finalBody != null && docBody != null)
                    {
                        foreach (var node in docBody.ChildNodes)
                        {
                            finalBody.AppendChild(finalDocument.ImportNode(node, true));
                        }
                    }
                }
            }

            if (finalDocument != null)
            {
                finalDocument.Save(outputPath);
                Console.WriteLine("Merged HTML saved at " + outputPath);
            }
            else
            {
                Console.WriteLine("No markdown files were processed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}