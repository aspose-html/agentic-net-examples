// Extract the text content of all list items within a navigation menu using a CSS selector.

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
            string html = @"<html><body><nav><ul><li>Home</li><li>About</li><li>Contact</li></ul></nav></body></html>";
            string baseUri = "http://example.com/";
            HTMLDocument document = new HTMLDocument(html, baseUri);
            NodeList elements = document.QuerySelectorAll("nav li");
            foreach (HTMLElement element in elements)
            {
                Console.WriteLine(element.InnerHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}