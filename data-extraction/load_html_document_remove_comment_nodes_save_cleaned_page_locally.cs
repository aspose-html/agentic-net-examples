// Load an HTML document, remove all comment nodes, and save the cleaned page locally.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><!--Sample comment--><head><title>Sample</title></head><body><p>Hello World</p><!--Another comment--></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove all comment nodes
            RemoveComments(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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