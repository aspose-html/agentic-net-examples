// Log the count of inline SVGs found on each processed page.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the page to process
            string url = "https://example.com";

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(url);

            // Retrieve all inline <svg> elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Count the number of SVG elements found
            int count = svgs.Length;

            // Log the count
            Console.WriteLine($"Found {count} inline SVG(s) on page: {url}");
        }
        catch (Exception ex)
        {
            // Log any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}