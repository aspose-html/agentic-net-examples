// Use QuerySelectorAll to retrieve all elements with class "highlight" on the page.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing elements with class "highlight"
            string htmlContent = "<html><body>" +
                                 "<p class='highlight'>First paragraph</p>" +
                                 "<div class='highlight'>Highlighted div</div>" +
                                 "<span>Normal span</span>" +
                                 "</body></html>";

            // Load the HTML into an Aspose.HTML document
            var document = new HTMLDocument(htmlContent, "");

            // Retrieve all elements that have the class "highlight"
            var nodes = document.QuerySelectorAll(".highlight");

            // Iterate over the returned collection using an index-based loop
            for (int i = 0; i < nodes.Length; i++)
            {
                // Cast each node to HTMLElement
                var element = nodes[i] as HTMLElement;
                if (element != null)
                {
                    // Output the outer HTML of each matched element
                    Console.WriteLine(element.OuterHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}