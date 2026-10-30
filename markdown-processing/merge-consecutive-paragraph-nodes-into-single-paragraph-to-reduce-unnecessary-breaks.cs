// Merge consecutive paragraph nodes into a single paragraph to reduce unnecessary breaks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>First</p><p>Second</p><p>Third</p><div>Other</div><p>Fourth</p><p>Fifth</p></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.HTMLElement body = doc.Body;

            bool IsParagraph(Aspose.Html.Dom.Node node)
            {
                if (node.NodeType != Aspose.Html.Dom.Node.ELEMENT_NODE)
                    return false;
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)node;
                return string.Equals(element.TagName, "p", StringComparison.OrdinalIgnoreCase);
            }

            for (int i = 0; i < body.ChildNodes.Length; i++)
            {
                Aspose.Html.Dom.Node currentNode = body.ChildNodes[i];
                if (!IsParagraph(currentNode))
                    continue;

                Aspose.Html.HTMLParagraphElement currentPara = (Aspose.Html.HTMLParagraphElement)currentNode;

                while (i + 1 < body.ChildNodes.Length && IsParagraph(body.ChildNodes[i + 1]))
                {
                    Aspose.Html.HTMLParagraphElement nextPara = (Aspose.Html.HTMLParagraphElement)body.ChildNodes[i + 1];
                    currentPara.TextContent = currentPara.TextContent + " " + nextPara.TextContent;
                    body.RemoveChild(nextPara);
                }
            }

            string outputPath = "merged.html";
            doc.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}