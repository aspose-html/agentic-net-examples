// Apply a custom NodeFilter that excludes nodes with display:none style during DOM traversal.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyVisibleFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        // Skip nodes that have style "display:none"
        if (n is Element element)
        {
            string style = element.GetAttribute("style");
            if (!string.IsNullOrEmpty(style) && style.IndexOf("display:none", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return FILTER_SKIP;
            }
        }
        return FILTER_ACCEPT;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Load an HTML document (replace with your HTML content or URL)
            var doc = new HTMLDocument("<html><head></head><body>" +
                                       "<div style=\"display:none\">Hidden</div>" +
                                       "<p>Visible paragraph</p>" +
                                       "<span style=\"color:red; display:none;\">Another hidden</span>" +
                                       "</body></html>");

            // Create a TreeWalker with the custom filter to skip display:none nodes
            ITreeWalker walker = doc.CreateTreeWalker(
                doc,
                NodeFilter.SHOW_ALL,
                new OnlyVisibleFilter()
            );

            // Traverse and output the local name of each accepted node
            Node current = walker.CurrentNode;
            while (current != null)
            {
                Console.WriteLine(current.LocalName);
                current = walker.NextNode();
            }

            // Save the document (optional)
            doc.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}