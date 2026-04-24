// Use CSS selectors to find all bold text elements and replace their inner HTML with uppercase text.

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
            string html = "<html><body><p>This is <b>bold</b> and <strong>strong</strong> text.</p></body></html>";
            string baseUri = "http://example.com";

            // Create an HTMLDocument from the string content
            HTMLDocument document = new HTMLDocument(html, baseUri);

            // Select all bold (<b>) and strong (<strong>) elements
            var elements = document.QuerySelectorAll("b, strong");

            // Replace inner HTML of each selected element with its uppercase version
            foreach (HTMLElement element in elements)
            {
                element.InnerHTML = element.InnerHTML.ToUpperInvariant();
            }

            // Save the modified document to a file
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}