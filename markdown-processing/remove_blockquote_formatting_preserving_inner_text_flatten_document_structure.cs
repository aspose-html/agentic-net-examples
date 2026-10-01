// Remove blockquote formatting while preserving the inner text to flatten document structure.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><p>Before</p><blockquote><p>Quote line 1</p><p>Quote line 2</p></blockquote><p>After</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);
            RemoveBlockquotes(document.DocumentElement);
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RemoveBlockquotes(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;
            if (child.NodeName.Equals("blockquote", System.StringComparison.OrdinalIgnoreCase))
            {
                var inner = child.FirstChild;
                while (inner != null)
                {
                    var innerNext = inner.NextSibling;
                    child.ParentNode.InsertBefore(inner, child);
                    inner = innerNext;
                }
                node.RemoveChild(child);
            }
            else
            {
                RemoveBlockquotes(child);
            }
            child = next;
        }
    }
}