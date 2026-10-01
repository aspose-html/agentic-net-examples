// Detect and remove empty elements that contain no child nodes or text content.

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
                File.WriteAllText(inputPath, "<html><body><div></div><p>Text</p><span>   </span><section><article></article></section></body></html>");
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                RemoveEmptyElements(document.DocumentElement);
                document.Save(outputPath);
            }

            Console.WriteLine("Empty elements removed and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void RemoveEmptyElements(Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            // Recursively process descendants first
            RemoveEmptyElements(child);

            if (child is Element element)
            {
                bool hasNoChildren = element.FirstChild == null;
                bool hasNoText = string.IsNullOrWhiteSpace(element.TextContent);
                if (hasNoChildren && hasNoText && element.ParentNode != null)
                {
                    element.ParentNode.RemoveChild(element);
                }
            }

            child = next;
        }
    }
}