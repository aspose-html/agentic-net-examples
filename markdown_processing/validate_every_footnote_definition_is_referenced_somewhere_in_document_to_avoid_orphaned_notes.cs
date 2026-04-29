// Validate that every footnote definition is referenced somewhere in the document to avoid orphaned notes.

using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("input.html");

            // Collect footnote definition IDs (elements with id starting with "fn")
            var footnoteDefs = document.QuerySelectorAll("[id^='fn']");
            var definitionIds = new HashSet<string>();
            foreach (Element element in footnoteDefs)
            {
                if (!string.IsNullOrEmpty(element.Id))
                    definitionIds.Add(element.Id);
            }

            // Collect referenced footnote IDs (anchor hrefs pointing to "#fn...")
            var footnoteRefs = document.QuerySelectorAll("a[href^='#fn']");
            var referencedIds = new HashSet<string>();
            foreach (Element element in footnoteRefs)
            {
                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href) && href.StartsWith("#"))
                    referencedIds.Add(href.Substring(1));
            }

            // Determine orphaned definitions
            var orphaned = definitionIds.Except(referencedIds);
            if (orphaned.Any())
            {
                Console.WriteLine("Orphaned footnote definitions found:");
                foreach (var id in orphaned)
                    Console.WriteLine($"- {id}");
            }
            else
            {
                Console.WriteLine("All footnote definitions are referenced.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}