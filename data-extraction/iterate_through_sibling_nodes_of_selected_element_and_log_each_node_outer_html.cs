// Iterate through sibling nodes of a selected element and log each node's outer HTML.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><div>First</div><p>Second</p><!-- comment --><span>Third</span></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, ""))
            {
                Aspose.Html.Dom.Node node = document.Body.FirstChild;
                while (node != null)
                {
                    if (node is Aspose.Html.HTMLElement element)
                    {
                        Console.WriteLine(element.OuterHTML);
                    }
                    node = node.NextSibling;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}