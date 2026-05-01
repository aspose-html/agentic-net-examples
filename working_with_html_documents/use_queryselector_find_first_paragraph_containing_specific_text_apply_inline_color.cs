// Use QuerySelector to find the first paragraph containing specific text and apply inline color.

using System;
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
            string targetText = "specific text";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Find the first paragraph element
            Element element = document.QuerySelector("p");

            // Apply inline color if the paragraph contains the target text
            if (element != null && element.TextContent != null && element.TextContent.Contains(targetText))
            {
                element.SetAttribute("style", "color:red;");
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}