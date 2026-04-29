// Add a custom attribute to heading nodes for SEO purposes without altering visible text.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Get the body element
            HTMLElement body = document.Body;

            // Create a heading element (h1)
            HTMLHeadingElement heading = (HTMLHeadingElement)document.CreateElement("h1");

            // Add visible text to the heading
            Text textNode = document.CreateTextNode("Sample Heading");
            heading.AppendChild(textNode);

            // Add a custom attribute for SEO purposes
            heading.SetAttribute("data-seo", "keyword");

            // Append the heading to the body
            body.AppendChild(heading);

            // Save the document to a file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}