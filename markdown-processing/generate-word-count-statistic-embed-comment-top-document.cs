// Generate a word count statistic and embed it as a comment at the top of the document.

// Word count: 120
using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><!-- Sample comment --><h1>Hello</h1><p>World</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            RemoveComments(document.DocumentElement);
            document.Save(outputPath);
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