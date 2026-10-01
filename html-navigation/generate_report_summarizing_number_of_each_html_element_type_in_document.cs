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
            string htmlContent = "<html><head><title>Sample</title></head><body><div><p>Paragraph</p><a href=\"#\">Link</a></div><ul><li>Item1</li><li>Item2</li></ul></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            HTMLCollection allElements = document.GetElementsByTagName("*");
            var tagCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < allElements.Length; i++)
            {
                var element = allElements[i] as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    string tagName = element.NodeName.ToLowerInvariant();
                    if (tagCounts.ContainsKey(tagName))
                        tagCounts[tagName]++;
                    else
                        tagCounts[tagName] = 1;
                }
            }

            Console.WriteLine("HTML Element Summary:");
            foreach (var kvp in tagCounts)
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