// Iterate through sibling nodes of a selected element and log each node's outer HTML.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><div id='selected'>First</div><p>Second</p><!-- comment --><span>Third</span></body></html>";
            string baseUri = "http://example.com";

            HTMLDocument document = new HTMLDocument(html, baseUri);

            HTMLElement selected = (HTMLElement)document.QuerySelector("#selected");
            if (selected == null) return;

            Node sibling = selected.NextSibling;
            while (sibling != null)
            {
                if (sibling is Element element)
                {
                    Console.WriteLine(element.OuterHTML);
                }
                else
                {
                    Console.WriteLine(sibling.TextContent);
                }
                sibling = sibling.NextSibling;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}