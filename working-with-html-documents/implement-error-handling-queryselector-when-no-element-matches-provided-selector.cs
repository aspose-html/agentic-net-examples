// Implement error handling for QuerySelector when no element matches the provided selector.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div id='test'>Hello</div></body></html>";
            // Load HTML from string; use two-argument constructor with a dummy base URI.
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Attempt to select an element that does not exist.
            Aspose.Html.Dom.Element element = document.QuerySelector("#missing");

            if (element == null)
            {
                System.Console.WriteLine("Element not found for selector '#missing'.");
            }
            else
            {
                // Cast to HTMLElement to access InnerHTML.
                var htmlElement = (Aspose.Html.HTMLElement)element;
                System.Console.WriteLine($"Found element content: {htmlElement.InnerHTML}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}