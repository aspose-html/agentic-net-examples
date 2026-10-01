// Remove duplicate ID attributes by appending numeric suffixes to ensure uniqueness throughout the document.

using System;
using System.Collections.Generic;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with duplicate IDs
            string htmlContent = "<html><body>" +
                                 "<div id='dup'>First</div>" +
                                 "<p id='dup'>Second</p>" +
                                 "<span id='unique'>Third</span>" +
                                 "<div id='dup'>Fourth</div>" +
                                 "</body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all elements in the document
            Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");

            // Track ID occurrences
            Dictionary<string, int> idCounts = new Dictionary<string, int>();

            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)allElements[i];

                if (element.HasAttribute("id"))
                {
                    string id = element.GetAttribute("id");

                    if (idCounts.ContainsKey(id))
                    {
                        idCounts[id] += 1;
                        string newId = id + "_" + idCounts[id];
                        element.SetAttribute("id", newId);
                    }
                    else
                    {
                        // First occurrence, keep original ID
                        idCounts[id] = 0;
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}