// Remove all empty paragraph nodes from the syntax tree to clean up the document structure.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><p></p><p>   </p><p>Content</p><div><p>Nested</p></div></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);
            RemoveEmptyParagraphs(document.DocumentElement);
            document.Save(outputPath);
            Console.WriteLine($"Processed document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RemoveEmptyParagraphs(Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            if (child.NodeName == "p")
            {
                var element = child as Element;
                if (element != null && string.IsNullOrWhiteSpace(element.TextContent))
                {
                    node.RemoveChild(child);
                }
                else
                {
                    RemoveEmptyParagraphs(child);
                }
            }
            else
            {
                RemoveEmptyParagraphs(child);
            }

            child = next;
        }
    }
}