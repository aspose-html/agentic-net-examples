// Load an HTML document, remove all comment nodes, and save the cleaned page locally.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><!-- comment --><head><title>Sample</title></head><body><p>Hello World</p><!-- another comment --></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            // Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove comment nodes recursively
            RemoveComments(document.DocumentElement);

            // Save cleaned document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        Aspose.Html.Dom.Node child = node.FirstChild;
        while (child != null)
        {
            Aspose.Html.Dom.Node next = child.NextSibling;

            // Use NodeName to identify comment nodes
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