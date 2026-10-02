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
            // Sample HTML content
            string htmlContent = @"
                <html>
                    <head>
                        <style>
                            .a { color: red; }
                            .b { font-weight: bold; }
                        </style>
                    </head>
                    <body>
                        <div class='a b'>Hello</div>
                        <p class='b c'>World</p>
                        <span class='a c d'>Sample</span>
                    </body>
                </html>";

            // Load the HTML document from the string (inline content)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have a class attribute
            NodeList elements = document.QuerySelectorAll("[class]");

            // Dictionary to hold class name frequencies
            Dictionary<string, int> classFrequency = new Dictionary<string, int>(StringComparer.Ordinal);

            // Iterate over the selected elements
            foreach (HTMLElement element in elements)
            {
                string classAttr = element.GetAttribute("class");
                if (string.IsNullOrWhiteSpace(classAttr))
                    continue;

                // Split class attribute value into individual class names
                string[] classes = classAttr.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string cls in classes)
                {
                    if (classFrequency.ContainsKey(cls))
                        classFrequency[cls]++;
                    else
                        classFrequency[cls] = 1;
                }
            }

            // Output the histogram
            Console.WriteLine("CSS Class Frequency Histogram:");
            foreach (KeyValuePair<string, int> kvp in classFrequency)
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