// Identify and extract microdata items using itemtype attributes and convert them to a structured list.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with microdata
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<div itemscope itemtype=\"http://schema.org/Person\">" +
                                 "<span itemprop=\"name\">John Doe</span>" +
                                 "<span itemprop=\"jobTitle\">Software Engineer</span>" +
                                 "</div>" +
                                 "<div itemscope itemtype=\"http://schema.org/Organization\">" +
                                 "<span itemprop=\"name\">Acme Corp</span>" +
                                 "<span itemprop=\"url\">https://www.acme.com</span>" +
                                 "</div>" +
                                 "</body></html>";

            // Load HTML document from string (use two‑argument constructor)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Find all elements that define a microdata item (have itemtype attribute)
                Aspose.Html.Collections.NodeList itemElements = document.QuerySelectorAll("[itemtype]");

                var result = new List<MicrodataItem>();

                for (int i = 0; i < itemElements.Length; i++)
                {
                    Aspose.Html.Dom.Element itemElement = (Aspose.Html.Dom.Element)itemElements[i];
                    string itemType = itemElement.GetAttribute("itemtype") ?? string.Empty;

                    // Find all descendant elements with itemprop attribute
                    Aspose.Html.Collections.NodeList propElements = itemElement.QuerySelectorAll("[itemprop]");

                    var properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                    for (int j = 0; j < propElements.Length; j++)
                    {
                        Aspose.Html.Dom.Element propElement = (Aspose.Html.Dom.Element)propElements[j];
                        string propName = propElement.GetAttribute("itemprop") ?? string.Empty;
                        string propValue = propElement.TextContent?.Trim() ?? string.Empty;

                        if (!string.IsNullOrEmpty(propName))
                        {
                            properties[propName] = propValue;
                        }
                    }

                    var microdataItem = new MicrodataItem
                    {
                        ItemType = itemType,
                        Properties = properties
                    };

                    result.Add(microdataItem);
                }

                // Serialize result to JSON and output
                var jsonOptions = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize(result, jsonOptions);
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Simple model to hold extracted microdata
    class MicrodataItem
    {
        public string ItemType { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}