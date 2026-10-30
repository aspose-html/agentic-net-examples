// Identify and extract microdata items using itemtype attributes and convert them to a structured list.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with microdata
            string htmlContent = @"
                <html>
                <body>
                    <div itemscope itemtype=""http://schema.org/Person"">
                        <span itemprop=""name"">John Doe</span>
                        <span itemprop=""jobTitle"">Software Engineer</span>
                        <div itemprop=""address"" itemscope itemtype=""http://schema.org/PostalAddress"">
                            <span itemprop=""streetAddress"">123 Main St</span>
                            <span itemprop=""addressLocality"">Anytown</span>
                        </div>
                    </div>
                    <div itemscope itemtype=""http://schema.org/Organization"">
                        <span itemprop=""name"">Acme Corp</span>
                        <span itemprop=""url"">https://www.acme.com</span>
                    </div>
                </body>
                </html>";

            // Load HTML document from string
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Find all elements with itemscope and itemtype
                Aspose.Html.Collections.NodeList itemElements = document.QuerySelectorAll("[itemscope][itemtype]");
                var resultList = new List<Dictionary<string, string>>();

                for (int i = 0; i < itemElements.Length; i++)
                {
                    HTMLElement itemElement = itemElements[i] as HTMLElement;
                    if (itemElement == null) continue;

                    string itemType = itemElement.GetAttribute("itemtype") ?? string.Empty;
                    var itemDict = new Dictionary<string, string>
                    {
                        { "type", itemType }
                    };

                    // Find all descendant elements with itemprop within the current item scope
                    Aspose.Html.Collections.NodeList propElements = itemElement.QuerySelectorAll("[itemprop]");
                    for (int j = 0; j < propElements.Length; j++)
                    {
                        HTMLElement propElement = propElements[j] as HTMLElement;
                        if (propElement == null) continue;

                        string propName = propElement.GetAttribute("itemprop") ?? string.Empty;
                        string propValue = propElement.TextContent?.Trim() ?? string.Empty;

                        // If the property already exists (e.g., nested items), concatenate values
                        if (itemDict.ContainsKey(propName))
                        {
                            itemDict[propName] = itemDict[propName] + "; " + propValue;
                        }
                        else
                        {
                            itemDict[propName] = propValue;
                        }
                    }

                    resultList.Add(itemDict);
                }

                // Serialize result to JSON and output
                string json = JsonSerializer.Serialize(resultList, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}