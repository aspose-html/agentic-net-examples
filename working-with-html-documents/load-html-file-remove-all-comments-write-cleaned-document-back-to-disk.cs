// Load an HTML file, remove all comments, and write the cleaned document back to disk.

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
                    "<!DOCTYPE html><html><!--Comment--><head><title>Test</title></head><body><p>Hello</p><!--Another comment--></body></html>");
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            RemoveComments(document.DocumentElement);
            document.Save(outputPath);

            Console.WriteLine("Comments removed and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RemoveComments(Node node)
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