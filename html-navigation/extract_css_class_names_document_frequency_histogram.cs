// Extract all CSS class names used in the document and output a frequency histogram.

using System;
using System.Collections.Generic;

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
                        <span class='text'>Span</span>
                        <ul class='list'>
                            <li class='item'>Item 1</li>
                            <li class='item special'>Item 2</li>
                        </ul>
                        <div class='footer'>Footer</div>
                    </body>
                </html>";

            // Load the HTML document from the string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Select all elements that have a class attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[class]");

            // Dictionary to hold class name frequencies
            var classFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string classAttr = element.GetAttribute("class");
                if (string.IsNullOrWhiteSpace(classAttr))
                    continue;

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
            foreach (var kvp in classFrequency)
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