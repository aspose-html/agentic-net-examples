// Use QuerySelector to retrieve the first matching paragraph element in the document.

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
            HTMLDocument document = new HTMLDocument("input.html");

            // Retrieve the first <p> element using a CSS selector
            Element paragraph = document.QuerySelector("p");

            if (paragraph != null)
            {
                // Output the inner HTML of the found paragraph
                Console.WriteLine(paragraph.InnerHTML);

                // Optional: modify the style of the paragraph
                paragraph.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            }
            else
            {
                Console.WriteLine("No paragraph element found.");
            }

            // Save the (potentially modified) document to a new file
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}