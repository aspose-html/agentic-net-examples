// Load an HTML document from a remote URL and extract all hyperlink URLs with a CSS selector.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load HTML document from a remote URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com");

            // Select all hyperlink elements using CSS selector
            Aspose.Html.Collections.NodeList linkNodes = document.QuerySelectorAll("a");

            // Iterate over the selected nodes and extract href attributes
            foreach (Aspose.Html.Dom.Node node in linkNodes)
            {
                if (node.NodeType == Aspose.Html.Dom.Node.ELEMENT_NODE)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)node;
                    string href = element.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        Console.WriteLine(href);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}