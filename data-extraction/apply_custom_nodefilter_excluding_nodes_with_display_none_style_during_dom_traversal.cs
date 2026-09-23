// Apply a custom NodeFilter that excludes nodes with display:none style during DOM traversal.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal.Filters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlContent = @"
                <html>
                    <head><style> .hidden { display:none; } </style></head>
                    <body>
                        <div id='visible'>Visible Div</div>
                        <div class='hidden' id='hidden'>Hidden Div</div>
                        <p style='display:none;'>Hidden Paragraph</p>
                        <span>Visible Span</span>
                    </body>
                </html>";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(new Aspose.Html.Url(inputPath));

            // Create custom filter to skip nodes with display:none
            var filter = new DisplayNoneFilter();

            // Traverse all elements and output node names that are not skipped
            var allElements = document.GetElementsByTagName("*");
            foreach (Aspose.Html.HTMLElement element in allElements)
            {
                if (filter.AcceptNode(element) == NodeFilter.FILTER_ACCEPT)
                {
                    Console.WriteLine($"Node: {element.NodeName}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom NodeFilter implementation
class DisplayNoneFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
{
    public override short AcceptNode(Aspose.Html.Dom.Node n)
    {
        // Check if the node is an HTMLElement
        var element = n as Aspose.Html.HTMLElement;
        if (element != null)
        {
            // Get the computed 'display' style value
            string display = element.Style.GetPropertyValue("display");
            if (!string.IsNullOrEmpty(display) &&
                string.Equals(display, "none", StringComparison.OrdinalIgnoreCase))
            {
                // Skip nodes with display:none
                return FILTER_SKIP;
            }
        }
        // Accept all other nodes
        return FILTER_ACCEPT;
    }
}