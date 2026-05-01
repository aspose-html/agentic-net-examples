// Use QuerySelectorAll to select all anchor tags and change their text color via inline style.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            var document = new HTMLDocument("input.html");

            // Select all anchor (<a>) elements
            NodeList anchors = document.QuerySelectorAll("a");

            // Change the text color of each anchor via inline style
            foreach (HTMLElement anchor in anchors)
            {
                anchor.Style.Color = "red";
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}