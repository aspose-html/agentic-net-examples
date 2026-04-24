// Use Document.QuerySelectorAll with a CSS selector to obtain all list items inside ordered lists.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing ordered lists
            string html = @"
                <html>
                    <body>
                        <ol>
                            <li>First item</li>
                            <li>Second item</li>
                        </ol>
                        <ol>
                            <li>Third item</li>
                        </ol>
                    </body>
                </html>";
            // Base URI required by the constructor
            string baseUri = "https://example.com";

            // Load the HTML into an Aspose.Html document
            HTMLDocument document = new HTMLDocument(html, baseUri);

            // Select all <li> elements that are descendants of <ol> elements
            var listItems = document.QuerySelectorAll("ol li");

            // Iterate over the resulting collection and output each item's outer HTML
            for (int i = 0; i < listItems.Length; i++)
            {
                var element = listItems[i] as HTMLElement;
                if (element != null)
                {
                    Console.WriteLine(element.OuterHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}