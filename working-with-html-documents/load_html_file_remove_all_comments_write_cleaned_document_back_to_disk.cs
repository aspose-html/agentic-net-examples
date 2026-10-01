// Load an HTML file, remove all comments, and write the cleaned document back to disk.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <!-- This is a comment that should be removed -->
    <p>Hello, World!</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove all comment nodes from the document
            RemoveComments(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);

            Console.WriteLine($"Document processed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

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