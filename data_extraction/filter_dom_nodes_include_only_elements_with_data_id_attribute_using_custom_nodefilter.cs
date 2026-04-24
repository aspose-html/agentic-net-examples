// Filter DOM nodes to include only elements with a data-id attribute using a custom NodeFilter.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing elements with and without data-id attribute
            string html = "<div data-id=\"1\"><p>First</p></div><span>No ID</span><section data-id=\"2\">Second</section>";
            string baseUri = "http://example.com";

            // Create an HTML document from the string and base URI
            HTMLDocument document = new HTMLDocument(html, baseUri);

            // Create a TreeWalker that traverses all nodes but applies the custom DataIdFilter
            ITreeWalker walker = document.CreateTreeWalker(document, NodeFilter.SHOW_ALL, new DataIdFilter());

            // Iterate over the filtered nodes and output their outer HTML
            while (walker.NextNode() != null)
            {
                Node current = walker.CurrentNode;
                if (current is Element element)
                {
                    Console.WriteLine(element.OuterHTML);
                }
            }

            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Custom NodeFilter that accepts only elements having a non‑empty data-id attribute
    class DataIdFilter : NodeFilter
    {
        public override short AcceptNode(Node n)
        {
            if (n is Element e && !string.IsNullOrEmpty(e.GetAttribute("data-id")))
                return FILTER_ACCEPT; // Include this node
            return FILTER_SKIP; // Exclude this node
        }
    }
}