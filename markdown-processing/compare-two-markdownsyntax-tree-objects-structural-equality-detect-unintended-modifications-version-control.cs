// Compare two MarkdownSyntaxTree objects for structural equality to detect unintended modifications during version control.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content (for demonstration, using simple HTML equivalents)
            string markdownContent1 = "<h1>Title</h1><p>Paragraph</p>";
            string markdownContent2 = "<h1>Title</h1><p>Paragraph</p>";

            // Load the content into HTMLDocument objects (using two-argument constructor with a dummy base URI)
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(markdownContent1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(markdownContent2, "about:blank");

            // Compare the body elements of both documents
            bool areEqual = AreNodesEqual(document1.Body, document2.Body);

            Console.WriteLine(areEqual
                ? "The Markdown syntax trees are structurally equal."
                : "The Markdown syntax trees differ.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool AreNodesEqual(Aspose.Html.Dom.Node node1, Aspose.Html.Dom.Node node2)
    {
        if (node1 == null || node2 == null)
            return node1 == node2;

        if (node1.NodeType != node2.NodeType)
            return false;

        if (node1 is Aspose.Html.HTMLElement elem1 && node2 is Aspose.Html.HTMLElement elem2)
        {
            if (elem1.OuterHTML != elem2.OuterHTML)
                return false;
        }

        var children1 = node1.ChildNodes;
        var children2 = node2.ChildNodes;

        if (children1.Length != children2.Length)
            return false;

        for (int i = 0; i < children1.Length; i++)
        {
            if (!AreNodesEqual(children1[i], children2[i]))
                return false;
        }

        return true;
    }
}