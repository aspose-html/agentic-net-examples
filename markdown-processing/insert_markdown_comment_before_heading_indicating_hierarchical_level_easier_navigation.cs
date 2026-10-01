// Insert a Markdown comment before each heading indicating its hierarchical level for easier navigation.

// # Setup
using System;
using System.IO;

class Program
{
    // # Entry Point
    static void Main()
    {
        try
        {
            // # Define paths
            string inputPath = "sample_input.html";
            string outputPath = "sample_output.html";

            // # Create sample input if missing
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <!-- This is a comment -->
</head>
<body>
    <h1>Hello World</h1>
    <!-- Another comment -->
    <p>Sample paragraph.</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // # Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // # Remove comments recursively
            RemoveComments(document.DocumentElement);

            // # Save result
            document.Save(outputPath);

            Console.WriteLine($"Processed file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // # Helper: RemoveComments
    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            // ✔ USE NodeName INSTEAD OF NodeType
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