// Generate a report summarizing the number of each HTML element type present in the document.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div><p>Paragraph</p><a href='https://example.com'>Link</a></div><ul><li>Item1</li><li>Item2</li></ul></body></html>";

            // Load HTML from a string using the two-argument constructor (content, baseUri)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements in the document
            Aspose.Html.Collections.NodeList allElements = document.QuerySelectorAll("*");

            var elementCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.Dom.Node node = allElements[i];
                if (node.NodeType == Aspose.Html.Dom.Node.ELEMENT_NODE)
                {
                    Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                    if (element != null)
                    {
                        string tagName = element.TagName;
                        if (elementCounts.ContainsKey(tagName))
                            elementCounts[tagName]++;
                        else
                            elementCounts[tagName] = 1;
                    }
                }
            }

            Console.WriteLine("HTML Element Summary:");
            foreach (var kvp in elementCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}