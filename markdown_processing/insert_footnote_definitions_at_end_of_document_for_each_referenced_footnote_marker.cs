// Insert footnote definitions at the end of the document for each referenced footnote marker.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace FootnoteInserter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the existing HTML document
                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    // Find all footnote reference links (e.g., <a href="#fn1">)
                    NodeList footnoteLinks = document.QuerySelectorAll("a[href^='#fn']");

                    // Collect unique footnote IDs
                    var footnoteIds = new System.Collections.Generic.HashSet<string>();
                    foreach (Node node in footnoteLinks)
                    {
                        if (node is Element element && element.HasAttribute("href"))
                        {
                            string href = element.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href) && href.StartsWith("#"))
                            {
                                footnoteIds.Add(href.Substring(1)); // remove leading '#'
                            }
                        }
                    }

                    if (footnoteIds.Count > 0)
                    {
                        // Create an ordered list to hold footnote definitions
                        Element ol = (Element)document.CreateElement("ol");
                        ol.SetAttribute("id", "footnotes");

                        foreach (string id in footnoteIds)
                        {
                            // Create a list item for each footnote definition
                            Element li = (Element)document.CreateElement("li");
                            li.SetAttribute("id", id);
                            li.TextContent = $"Footnote definition for {id}";
                            ol.AppendChild(li);
                        }

                        // Append the footnote list to the end of the body
                        document.Body.AppendChild(ol);
                    }

                    // Save the modified document
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}