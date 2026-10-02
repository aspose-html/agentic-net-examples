// Merge consecutive paragraph nodes into a single paragraph to reduce unnecessary breaks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>First.</p><p>Second.</p><p>Third.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var body = document.Body;
            var node = body.FirstChild;
            while (node != null)
            {
                var next = node.NextSibling;
                if (node is Aspose.Html.HTMLParagraphElement && next is Aspose.Html.HTMLParagraphElement)
                {
                    var firstP = (Aspose.Html.HTMLParagraphElement)node;
                    var secondP = (Aspose.Html.HTMLParagraphElement)next;

                    var spaceNode = document.CreateTextNode(" ");
                    firstP.AppendChild(spaceNode);

                    var child = secondP.FirstChild;
                    while (child != null)
                    {
                        var nextChild = child.NextSibling;
                        secondP.RemoveChild(child);
                        firstP.AppendChild(child);
                        child = nextChild;
                    }

                    body.RemoveChild(secondP);
                    continue;
                }
                node = next;
            }

            string outputPath = "merged.html";
            document.Save(outputPath);
            Console.WriteLine("Merged HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}