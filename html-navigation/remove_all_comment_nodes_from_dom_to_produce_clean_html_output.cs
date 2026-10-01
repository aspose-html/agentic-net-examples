// Remove all comment nodes from the DOM to produce a clean HTML output.

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
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><!-- comment --><head><title>Test</title></head><body><!-- another comment --><p>Hello</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            RemoveComments(document.DocumentElement);
            document.Save(outputPath);

            Console.WriteLine("Clean HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;
            if (child.NodeName == "#comment")
            {
                node.RemoveChild(child);
            }
            else
            {
                RemoveComments(child);
            }
            child = next;
        }
    }
}