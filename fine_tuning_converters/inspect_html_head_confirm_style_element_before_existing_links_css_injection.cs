// After injecting CSS, inspect the generated HTML head to confirm the style element appears before existing links.

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
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a style element with the desired CSS
            Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253); }";

            // Get the head element
            Element head = document.GetElementsByTagName("head").First();

            // Insert the style element at the beginning of the head
            head.InsertBefore(style, head.FirstChild);

            // Verify that the style element appears before any link elements
            int styleIndex = -1;
            int firstLinkIndex = int.MaxValue;
            int index = 0;
            foreach (var child in head.ChildNodes)
            {
                string nodeName = child.NodeName?.ToLowerInvariant();
                if (nodeName == "style")
                    styleIndex = index;
                if (nodeName == "link")
                    firstLinkIndex = Math.Min(firstLinkIndex, index);
                index++;
            }

            bool styleBeforeLinks = styleIndex >= 0 && styleIndex < firstLinkIndex;
            Console.WriteLine(styleBeforeLinks ? "Style element is before link elements." : "Style element is not before link elements.");

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}