// Remove all Markdown comments from the document to produce a clean version without annotations.

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

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><!-- Comment to remove --><p>Hello World!</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove all comment nodes
            RemoveComments(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);

            Console.WriteLine("Comments removed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        Aspose.Html.Dom.Node child = node.FirstChild;
        while (child != null)
        {
            Aspose.Html.Dom.Node next = child.NextSibling;

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