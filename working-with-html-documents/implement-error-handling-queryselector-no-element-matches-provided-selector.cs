// Implement error handling for QuerySelector when no element matches the provided selector.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><div id='test'>Hello World</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Attempt to select an existing element
            var existingElement = document.QuerySelector("#test");
            if (existingElement != null)
            {
                var htmlElement = (Aspose.Html.HTMLElement)existingElement;
                Console.WriteLine("Found element: " + htmlElement.InnerHTML);
            }
            else
            {
                Console.WriteLine("Element with selector '#test' not found.");
            }

            // Attempt to select a non‑existent element
            var missingElement = document.QuerySelector(".nonexistent");
            if (missingElement == null)
            {
                Console.WriteLine("No element matches selector '.nonexistent'.");
            }
            else
            {
                Console.WriteLine("Unexpectedly found an element for selector '.nonexistent'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}