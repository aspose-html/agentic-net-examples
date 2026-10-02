// Generate a report summarizing the number of each HTML element type present in the document.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div><p>Paragraph</p><a href=\"#\">Link</a></div><ul><li>Item1</li><li>Item2</li></ul></body></html>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                HTMLCollection allElements = document.GetElementsByTagName("*");
                var elementCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < allElements.Length; i++)
                {
                    Element element = allElements[i] as Element;
                    if (element == null)
                        continue;

                    string tagName = element.NodeName;
                    if (string.IsNullOrEmpty(tagName))
                        continue;

                    if (elementCounts.ContainsKey(tagName))
                        elementCounts[tagName]++;
                    else
                        elementCounts[tagName] = 1;
                }

                Console.WriteLine("HTML Element Summary:");
                foreach (var kvp in elementCounts)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}