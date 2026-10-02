// Replace double spaces with single spaces in all text nodes to improve readability.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>This  is  a  sample  text.</p><div>Another   example   here.</div></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                ProcessNode(document.Body);
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Processed HTML saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ProcessNode(Aspose.Html.Dom.Node node)
    {
        if (node is Aspose.Html.Dom.Text textNode)
        {
            string original = textNode.TextContent;
            string replaced = Regex.Replace(original, " {2,}", " ");
            textNode.TextContent = replaced;
        }

        Aspose.Html.Dom.Node child = node.FirstChild;
        while (child != null)
        {
            ProcessNode(child);
            child = child.NextSibling;
        }
    }
}