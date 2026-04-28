// Identify and extract microdata items using itemtype attributes and convert them to a structured list.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace MicrodataExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://example.com";
                var items = new List<MicrodataItem>();
                using (var document = new HTMLDocument(url))
                {
                    var allElements = document.GetElementsByTagName("*");
                    foreach (var node in allElements)
                    {
                        if (node is Element element)
                        {
                            string itemtype = element.GetAttribute("itemtype");
                            if (!string.IsNullOrEmpty(itemtype))
                            {
                                var microItem = new MicrodataItem
                                {
                                    ItemType = itemtype,
                                    Properties = new Dictionary<string, string>()
                                };
                                var propElements = element.QuerySelectorAll("[itemprop]");
                                foreach (var pNode in propElements)
                                {
                                    if (pNode is Element propElement)
                                    {
                                        string propName = propElement.GetAttribute("itemprop");
                                        if (!string.IsNullOrEmpty(propName))
                                        {
                                            string propValue = propElement.TextContent?.Trim() ?? string.Empty;
                                            microItem.Properties[propName] = propValue;
                                        }
                                    }
                                }
                                items.Add(microItem);
                            }
                        }
                    }
                }
                foreach (var item in items)
                {
                    Console.WriteLine($"ItemType: {item.ItemType}");
                    foreach (var kvp in item.Properties)
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    class MicrodataItem
    {
        public string ItemType { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}