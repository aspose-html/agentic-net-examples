// Detect duplicate meta tags and retain only the first occurrence to avoid conflicts.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace MetaTagDeduplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output HTML file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Get all <meta> elements
                HTMLCollection metaCollection = document.GetElementsByTagName("meta");

                // Track seen meta identifiers (name or http-equiv)
                HashSet<string> seenMeta = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                // Iterate backwards to safely remove duplicates while iterating
                for (int i = metaCollection.Length - 1; i >= 0; i--)
                {
                    // Cast each item to Element
                    Element metaElement = metaCollection[i] as Element;
                    if (metaElement == null)
                        continue;

                    // Determine a key for duplication check
                    string nameAttr = metaElement.GetAttribute("name");
                    string httpEquivAttr = metaElement.GetAttribute("http-equiv");
                    string key = !string.IsNullOrEmpty(nameAttr) ? nameAttr :
                                 !string.IsNullOrEmpty(httpEquivAttr) ? httpEquivAttr :
                                 metaElement.OuterHTML; // fallback to full markup

                    // If the key already exists, remove the duplicate meta tag
                    if (!seenMeta.Add(key))
                    {
                        Node parent = metaElement.ParentNode;
                        if (parent != null)
                        {
                            parent.RemoveChild(metaElement);
                        }
                    }
                }

                // Save the cleaned document
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}