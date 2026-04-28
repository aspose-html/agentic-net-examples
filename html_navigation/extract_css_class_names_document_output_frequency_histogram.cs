// Extract all CSS class names used in the document and output a frequency histogram.

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
            // Load the HTML document from a file
            string htmlPath = "input.html";
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Select all elements in the document
            NodeList elements = document.QuerySelectorAll("*");

            // Dictionary to hold class name frequencies
            var classCounts = new Dictionary<string, int>(StringComparer.Ordinal);

            // Iterate over each element and collect class names
            foreach (HTMLElement element in elements)
            {
                string classAttr = element.ClassName;
                if (string.IsNullOrWhiteSpace(classAttr))
                    continue;

                // Split multiple class names separated by spaces
                string[] classes = classAttr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string cls in classes)
                {
                    if (classCounts.ContainsKey(cls))
                        classCounts[cls]++;
                    else
                        classCounts[cls] = 1;
                }
            }

            // Output the histogram to the console
            foreach (var kvp in classCounts)
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