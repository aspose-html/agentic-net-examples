// Apply a custom NodeFilter to extract only script tags while ignoring other elements.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyScriptFilter : NodeFilter
{
    // Accept only nodes whose local name is "script"
    public override short AcceptNode(Node n)
    {
        return string.Equals("script", n.LocalName, StringComparison.OrdinalIgnoreCase)
            ? FILTER_ACCEPT
            : FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing script tags and other elements
            string html = @"
                <html>
                    <head>
                        <script src='a.js'></script>
                    </head>
                    <body>
                        <script>console.log('Hello');</script>
                        <div>Some content</div>
                    </body>
                </html>";

            // Load the HTML into an Aspose.HTML document
            HTMLDocument document = new HTMLDocument(html, "http://example.com/");

            // Create a TreeWalker that traverses all nodes but filters only script elements
            ITreeWalker walker = document.CreateTreeWalker(
                document,
                NodeFilter.SHOW_ALL,
                new OnlyScriptFilter());

            // Iterate through the filtered nodes and output their outer HTML
            while (walker.NextNode() != null)
            {
                Node current = walker.CurrentNode;
                if (current is Element element)
                {
                    Console.WriteLine(element.OuterHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}