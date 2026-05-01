// Implement error handling for QuerySelector when no element matches the provided selector.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><div id='content'>Hello World</div></body></html>";
            // Create an HTMLDocument from the string
            HTMLDocument document = new HTMLDocument(html);

            // CSS selector that does not exist in the document
            string selector = "#nonexistent";

            // Attempt to find the element
            var element = document.QuerySelector(selector);

            // Check if the element was found
            if (element == null)
            {
                Console.WriteLine($"No element matches the selector '{selector}'.");
            }
            else
            {
                Console.WriteLine($"Element found: {element.OuterHTML}");
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}