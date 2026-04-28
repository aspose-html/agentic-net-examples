// Extract all anchor elements that open in a new window (target="_blank") for security review.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL or file path
            string source = "https://example.com"; // TODO: replace with actual source
            HTMLDocument document = new HTMLDocument(source);

            // Select all anchor elements that open in a new window (target="_blank")
            NodeList blankAnchors = document.QuerySelectorAll("a[target='_blank']");

            // Iterate through the selected anchors and output their href and text
            foreach (HTMLElement anchor in blankAnchors)
            {
                string href = anchor.GetAttribute("href");
                string text = anchor.TextContent != null ? anchor.TextContent.Trim() : string.Empty;
                Console.WriteLine($"Href: {href}, Text: {text}");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}