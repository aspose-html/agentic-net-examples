// Create a style element with a red text rule, insert it into head, and verify visual change.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a style element with a red text rule
            Element style = document.CreateElement("style");
            style.TextContent = "body { color: red; }";

            // Get the head element and append the style element
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document to verify the visual change
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}