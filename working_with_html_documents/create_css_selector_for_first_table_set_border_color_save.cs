// Create a CSS selector for the first table element and set its border-color, then save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source HTML document
            var document = new HTMLDocument("input.html");

            // Select the first table element
            var element = document.QuerySelector("table");

            // Apply inline CSS to set the border color
            element.SetAttribute("style", "border-color: #0000ff;");

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}