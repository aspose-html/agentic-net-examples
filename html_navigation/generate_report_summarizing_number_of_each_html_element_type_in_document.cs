// Generate a report summarizing the number of each HTML element type present in the document.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file path
            HTMLDocument document = new HTMLDocument("input.html");

            // Get all elements in the document
            HTMLCollection allElements = document.GetElementsByTagName("*");

            // Dictionary to hold element tag name counts
            Dictionary<string, int> elementCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Iterate over all elements and count by tag name
            for (int i = 0; i < allElements.Length; i++)
            {
                HTMLElement element = allElements[i] as HTMLElement;
                if (element != null)
                {
                    string tag = element.TagName;
                    if (elementCounts.ContainsKey(tag))
                        elementCounts[tag]++;
                    else
                        elementCounts[tag] = 1;
                }
            }

            // Output the summary report
            Console.WriteLine("HTML Element Type Summary:");
            foreach (var kvp in elementCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}