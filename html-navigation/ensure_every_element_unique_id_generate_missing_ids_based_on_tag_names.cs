// Ensure every element has a unique ID by generating missing IDs based on tag names.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><title>Sample</title></head><body><div><p>Paragraph</p><span></span></div><img src='image.png'></body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Get all elements in the document
            Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");

            // Track used IDs to ensure uniqueness
            HashSet<string> usedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // First, collect existing IDs
            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)allElements[i];
                string existingId = element.GetAttribute("id");
                if (!string.IsNullOrEmpty(existingId))
                {
                    usedIds.Add(existingId);
                }
            }

            // Assign missing IDs
            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)allElements[i];
                string id = element.GetAttribute("id");
                if (string.IsNullOrEmpty(id))
                {
                    string baseId = element.TagName.ToLowerInvariant() + "_" + i;
                    string newId = baseId;
                    int suffix = 1;
                    while (usedIds.Contains(newId))
                    {
                        newId = baseId + "_" + suffix;
                        suffix++;
                    }
                    element.SetAttribute("id", newId);
                    usedIds.Add(newId);
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Modified HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}