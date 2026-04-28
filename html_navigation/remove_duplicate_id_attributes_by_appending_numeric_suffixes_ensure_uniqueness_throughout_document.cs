// Remove duplicate ID attributes by appending numeric suffixes to ensure uniqueness throughout the document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Retrieve all elements in the document
            HTMLCollection allElements = document.GetElementsByTagName("*");

            // Track occurrences of each ID
            var idCounts = new System.Collections.Generic.Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < allElements.Length; i++)
            {
                HTMLElement element = (HTMLElement)allElements[i];
                string id = element.GetAttribute("id");

                if (!string.IsNullOrEmpty(id))
                {
                    if (idCounts.ContainsKey(id))
                    {
                        // Increment counter and create a new unique ID
                        idCounts[id]++;
                        string newId = $"{id}_{idCounts[id]}";
                        element.SetAttribute("id", newId);
                    }
                    else
                    {
                        // First occurrence of this ID
                        idCounts[id] = 0;
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}