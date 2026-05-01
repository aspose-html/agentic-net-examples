// Verify that style changes have been applied by inspecting the style attribute of a target element.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace VerifyStyleChange
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the HTML file to be inspected
                string htmlPath = "input.html";

                // CSS selector that identifies the target element
                string selector = "#target";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Find the first element that matches the selector
                Element targetElement = document.QuerySelector(selector);

                if (targetElement != null)
                {
                    // Retrieve the value of the style attribute
                    string styleAttribute = targetElement.GetAttribute("style");

                    // Output the style attribute to verify changes
                    Console.WriteLine($"Style attribute of element '{selector}': {styleAttribute}");
                }
                else
                {
                    Console.WriteLine($"Element with selector '{selector}' was not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}