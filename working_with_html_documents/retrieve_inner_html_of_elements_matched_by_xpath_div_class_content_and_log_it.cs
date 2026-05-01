// Retrieve inner HTML of elements matched by XPath "//div[@class='content']" and log it.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = @"<html><body>
                <div class='content'><p>Hello</p></div>
                <div class='content'>World</div>
                </body></html>";
            // Base URI required by the HTMLDocument constructor
            string baseUri = "http://example.com";

            // Load the HTML into an Aspose.HTML document
            HTMLDocument document = new HTMLDocument(html, baseUri);

            // Select all <div class='content'> elements using a CSS selector
            var elements = document.QuerySelectorAll("div.content");

            // Iterate over the matched elements and output their inner HTML
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                Console.WriteLine(element.InnerHTML);
            }
        }
        catch (Exception ex)
        {
            // Log any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}