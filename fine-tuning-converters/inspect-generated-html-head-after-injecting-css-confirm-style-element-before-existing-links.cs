// After injecting CSS, inspect the generated HTML head to confirm the style element appears before existing links.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an existing <link> element
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><p>Hello, World!</p></body></html>";

            // Load the HTML document from inline content (use two‑argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a <style> element with CSS
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Get the <head> element
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];

            // Insert the style element before the first existing <link> element, if any
            Aspose.Html.Collections.HTMLCollection links = head.GetElementsByTagName("link");
            if (links.Length > 0)
            {
                Aspose.Html.HTMLElement firstLink = (Aspose.Html.HTMLElement)links[0];
                head.InsertBefore(style, firstLink);
            }
            else
            {
                head.AppendChild(style);
            }

            // Verify that the <style> element appears before the first <link> element
            bool styleBeforeLink = false;
            Aspose.Html.Collections.NodeList children = head.ChildNodes;
            for (int i = 0; i < children.Length; i++)
            {
                Node node = (Node)children[i];
                if (node.NodeType == Node.ELEMENT_NODE)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)node;
                    if (element.TagName.Equals("style", StringComparison.OrdinalIgnoreCase))
                    {
                        if (i + 1 < children.Length && children[i + 1] is Node nextNode && nextNode.NodeType == Node.ELEMENT_NODE)
                        {
                            Aspose.Html.HTMLElement nextElement = (Aspose.Html.HTMLElement)nextNode;
                            if (nextElement.TagName.Equals("link", StringComparison.OrdinalIgnoreCase))
                            {
                                styleBeforeLink = true;
                            }
                        }
                        break;
                    }
                }
            }

            Console.WriteLine(styleBeforeLink
                ? "Style element is correctly placed before the first link."
                : "Style element is NOT placed before the first link.");

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine("Modified HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}