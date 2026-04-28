// Extract breadcrumb navigation links by locating ordered list elements with specific class names.

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
            // Sample HTML containing a breadcrumb ordered list
            string htmlContent = @"
                <html>
                    <body>
                        <ol class='breadcrumb'>
                            <li><a href='https://example.com/home'>Home</a></li>
                            <li><a href='https://example.com/category'>Category</a></li>
                            <li><a href='https://example.com/item'>Item</a></li>
                        </ol>
                    </body>
                </html>";

            // Create an HTMLDocument from the HTML string (base URI is empty)
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            // Select all anchor elements inside ordered lists with class 'breadcrumb'
            NodeList anchorElements = document.QuerySelectorAll("ol.breadcrumb a");

            // Iterate over the selected anchors and output their text and href
            foreach (HTMLElement anchor in anchorElements)
            {
                string href = anchor.GetAttribute("href");
                string text = anchor.TextContent != null ? anchor.TextContent.Trim() : string.Empty;
                Console.WriteLine($"{text} -> {href}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}