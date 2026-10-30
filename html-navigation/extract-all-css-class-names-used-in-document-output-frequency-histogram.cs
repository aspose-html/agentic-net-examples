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
                    <head><title>Sample</title></head>
                    <body>
                        <div class='header main'>Header</div>
                        <p class='text main'>Paragraph 1</p>
                        <span class='text'>Span 1</span>
                        <div class='footer'>Footer</div>
                        <p class='text'>Paragraph 2</p>
                        <div class='header'>Another Header</div>
                    </body>
                </html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have a class attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[class]");

            // Dictionary to hold class name frequencies
            Dictionary<string, int> classCounts = new Dictionary<string, int>(StringComparer.Ordinal);

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string classAttr = element.GetAttribute("class");
                if (string.IsNullOrWhiteSpace(classAttr))
                    continue;

                string[] classes = classAttr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string cls in classes)
                {
                    if (classCounts.ContainsKey(cls))
                        classCounts[cls]++;
                    else
                        classCounts[cls] = 1;
                }
            }

            // Output histogram
            Console.WriteLine("CSS Class Frequency Histogram:");
            foreach (KeyValuePair<string, int> kvp in classCounts)
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