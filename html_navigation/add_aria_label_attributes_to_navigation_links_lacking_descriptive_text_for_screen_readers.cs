// Add aria‑label attributes to navigation links lacking descriptive text for screen readers.

using System;
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
            using (HTMLDocument document = new HTMLDocument("input.html"))
            {
                // Get all anchor elements in the document
                HTMLCollection anchors = document.GetElementsByTagName("a");
                for (int i = 0; i < anchors.Length; i++)
                {
                    Element link = anchors[i] as Element;
                    if (link == null) continue;

                    // Check if the link has visible text
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                    if (string.IsNullOrEmpty(text))
                    {
                        // Retrieve the href attribute
                        string href = link.GetAttribute("href") ?? string.Empty;
                        // Add aria-label attribute for screen readers
                        link.SetAttribute("aria-label", href);
                    }
                }

                // Save the modified document
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}