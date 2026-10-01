// Create a function that accepts a CSS selector and returns the inner text of the first matching element.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // CSS selector to search for
            string selector = "p";

            // Retrieve inner text of the first matching element
            string innerText = GetInnerText(selector);

            // Output the result
            System.Console.WriteLine(innerText ?? "No matching element found");
        }
        catch (System.Exception ex)
        {
            // Print any errors that occur during execution
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Returns the inner text of the first element that matches the provided CSS selector
    static string GetInnerText(string selector)
    {
        // Sample HTML content
        string html = "<html><body><div class='test'><p>Hello World</p></div></body></html>";

        // Create an Aspose.Html.HTMLDocument from the HTML string and a base URI
        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "http://example.com");

        // Query the document for the first element matching the selector
        Aspose.Html.Dom.Element element = document.QuerySelector(selector);

        // If no element is found, return null
        if (element == null)
            return null;

        // Return the text content of the element
        return element.TextContent;
    }
}