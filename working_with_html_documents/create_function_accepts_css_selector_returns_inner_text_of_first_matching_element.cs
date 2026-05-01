// Create a function that accepts a CSS selector and returns the inner text of the first matching element.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><div class='content'><p>Hello World</p></div></body></html>";
                string selector = "p";

                string result = GetFirstElementInnerText(html, selector);
                Console.WriteLine(result ?? "No matching element found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string GetFirstElementInnerText(string htmlContent, string cssSelector)
        {
            // Create an HTMLDocument from the HTML string (base URI is empty)
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            // Retrieve the first element that matches the selector
            Element element = document.QuerySelector(cssSelector);

            // Return its inner HTML (or null if not found)
            return element?.InnerHTML;
        }
    }
}