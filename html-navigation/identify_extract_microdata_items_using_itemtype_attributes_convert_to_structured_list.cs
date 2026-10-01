// Identify and extract microdata items using itemtype attributes and convert them to a structured list.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with microdata
            string htmlContent = @"<!DOCTYPE html>
<html>
<body>
  <div itemscope itemtype=""http://schema.org/Person"">
    <span itemprop=""name"">John Doe</span>
    <img itemprop=""image"" src=""john.jpg"" />
    <span itemprop=""jobTitle"">Software Engineer</span>
  </div>
  <div itemscope itemtype=""http://schema.org/Organization"">
    <span itemprop=""name"">Acme Corp</span>
    <span itemprop=""url"">https://www.acme.com</span>
  </div>
</body>
</html>";

            // Write HTML to a temporary file
            string tempHtmlPath = Path.Combine(Path.GetTempPath(), "microdata_sample.html");
            File.WriteAllText(tempHtmlPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempHtmlPath))
            {
                // Select all elements that have both itemscope and itemtype attributes
                Aspose.Html.Collections.NodeList itemElements = document.QuerySelectorAll("[itemscope][itemtype]");

                var resultList = new List<Dictionary<string, string>>();

                for (int i = 0; i < itemElements.Length; i++)
                {
                    Aspose.Html.Dom.Element itemElement = itemElements[i] as Aspose.Html.Dom.Element;
                    if (itemElement == null)
                        continue;

                    string itemType = itemElement.GetAttribute("itemtype") ?? string.Empty;

                    var itemData = new Dictionary<string, string>
                    {
                        { "type", itemType }
                    };

                    // Find all child elements with itemprop attribute within the current item scope
                    Aspose.Html.Collections.NodeList propElements = itemElement.QuerySelectorAll("[itemprop]");

                    for (int j = 0; j < propElements.Length; j++)
                    {
                        Aspose.Html.Dom.Element propElement = propElements[j] as Aspose.Html.Dom.Element;
                        if (propElement == null)
                            continue;

                        string propName = propElement.GetAttribute("itemprop") ?? string.Empty;
                        string propValue = propElement.TextContent?.Trim() ?? string.Empty;

                        // For elements like <img>, use the src attribute as value if text is empty
                        if (string.IsNullOrEmpty(propValue) && propElement.TagName.Equals("img", StringComparison.OrdinalIgnoreCase))
                        {
                            propValue = propElement.GetAttribute("src") ?? string.Empty;
                        }

                        if (!string.IsNullOrEmpty(propName))
                        {
                            itemData[propName] = propValue;
                        }
                    }

                    resultList.Add(itemData);
                }

                // Serialize result to JSON and output
                string jsonResult = JsonSerializer.Serialize(resultList, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(jsonResult);
            }

            // Clean up temporary file
            if (File.Exists(tempHtmlPath))
            {
                File.Delete(tempHtmlPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}