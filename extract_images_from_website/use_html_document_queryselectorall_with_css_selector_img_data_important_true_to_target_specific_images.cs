// Use HtmlDocument.QuerySelectorAll with CSS selector "img[data-important='true']" to target specific images.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            using (HTMLDocument document = new HTMLDocument("input.html"))
            {
                // Select all <img> elements with data-important='true'
                var importantImages = document.QuerySelectorAll("img[data-important='true']");

                // Iterate over the selected images
                foreach (Element img in importantImages)
                {
                    // Example operation: output the image source
                    Console.WriteLine(((HTMLImageElement)img).Src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}