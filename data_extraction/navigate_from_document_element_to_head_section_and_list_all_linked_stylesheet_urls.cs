// Navigate from the document element to the head section and list all linked stylesheet URLs.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file or URL
            var document = new HTMLDocument("input.html");

            // Access the collection of style sheets linked or embedded in the document
            var styleSheets = document.StyleSheets;

            // Iterate through each style sheet and output its href (URL) if available
            foreach (var sheet in styleSheets)
            {
                // The Href property is null for inline style sheets
                if (!string.IsNullOrEmpty(sheet.Href))
                {
                    Console.WriteLine(sheet.Href);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}