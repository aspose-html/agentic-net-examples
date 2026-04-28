// Add a custom data‑attribute to all heading elements for JavaScript interaction later.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            HTMLDocument document = new HTMLDocument();

            // Access the body element
            HTMLElement body = document.Body;

            // Add a sample heading to demonstrate the attribute addition
            HTMLHeadingElement heading = (HTMLHeadingElement)document.CreateElement("h1");
            Text headingText = document.CreateTextNode("Sample Heading");
            heading.AppendChild(headingText);
            body.AppendChild(heading);

            // Select all heading elements (h1–h6)
            var headingNodes = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

            // Iterate over the collection and set a custom data‑attribute
            for (int i = 0; i < headingNodes.Length; i++)
            {
                // Cast each node to HTMLElement to access SetAttribute
                HTMLElement element = (HTMLElement)headingNodes[i];
                element.SetAttribute("data-custom", "myValue");
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}