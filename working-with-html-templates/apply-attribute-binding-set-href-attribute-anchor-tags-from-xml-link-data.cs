// Apply attribute binding to set the href attribute of anchor tags from XML link data.

using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><a>Google</a> <a>Microsoft</a></body></html>";
            string xmlContent = "<links><link href=\"https://www.google.com\">Google</link><link href=\"https://www.microsoft.com\">Microsoft</link></links>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                var linkMap = new Dictionary<string, string>();
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);
                var xmlLinks = xmlDoc.SelectNodes("//link");
                if (xmlLinks != null)
                {
                    foreach (XmlNode node in xmlLinks)
                    {
                        var href = node.Attributes["href"]?.Value;
                        var text = node.InnerText?.Trim();
                        if (!string.IsNullOrEmpty(href) && !string.IsNullOrEmpty(text))
                        {
                            linkMap[text] = href;
                        }
                    }
                }

                var anchors = document.QuerySelectorAll("a");
                for (int i = 0; i < anchors.Length; i++)
                {
                    var el = (Aspose.Html.Dom.Element)anchors[i];
                    var linkText = el.TextContent?.Trim();
                    if (!string.IsNullOrEmpty(linkText) && linkMap.TryGetValue(linkText, out var newHref))
                    {
                        el.SetAttribute("href", newHref);
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"HTML saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}