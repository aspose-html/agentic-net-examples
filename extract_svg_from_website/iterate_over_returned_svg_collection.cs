// Iterate over the returned SVG collection.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL
            string url = "https://example.com";
            HTMLDocument document = new HTMLDocument(url);

            // Retrieve all inline SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Iterate over the collection
            for (int i = 0; i < svgs.Length; i++)
            {
                // Generate a file name for each SVG (e.g., for later saving)
                string fileName = $"svg_{i}.svg";

                // Placeholder for further processing of svgs[i]
                // e.g., var svgElement = svgs[i];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}