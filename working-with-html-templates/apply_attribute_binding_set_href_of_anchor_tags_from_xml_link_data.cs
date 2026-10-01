// Apply attribute binding to set the href attribute of anchor tags from XML link data.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script src=""sample.js""></script>
</head>
<body>
    <table>
        <tr><td><a href=""https://example.com"">Example Link</a></td></tr>
    </table>
    <button onclick=""alert('Clicked!')"">Click Me</button>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Extract links from tables
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
            var linkResults = new List<Dictionary<string, string>>();

            for (int t = 0; t < tables.Length; t++)
            {
                Aspose.Html.HTMLElement htmlTable = tables[t] as Aspose.Html.HTMLElement;
                if (htmlTable != null)
                {
                    Aspose.Html.Collections.HTMLCollection links = htmlTable.GetElementsByTagName("a");
                    for (int i = 0; i < links.Length; i++)
                    {
                        Aspose.Html.Dom.Element link = links[i];
                        string href = link.GetAttribute("href");
                        string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                        if (!string.IsNullOrEmpty(href))
                        {
                            var item = new Dictionary<string, string>
                            {
                                { "href", href },
                                { "text", text }
                            };
                            linkResults.Add(item);
                        }
                    }
                }
            }

            Console.WriteLine("Links found in tables:");
            foreach (var item in linkResults)
            {
                Console.WriteLine($"Href: {item["href"]}, Text: {item["text"]}");
            }

            // List script src attributes
            Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");
            Console.WriteLine("\nScript sources:");
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine(src);
                }
            }

            // Evaluate an XPath expression
            Aspose.Html.Dom.XPath.IXPathResult xpathResult = document.Evaluate("//a", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Console.WriteLine("\nXPath evaluation results (href values):");
            Aspose.Html.Dom.Node node;
            while ((node = xpathResult.IterateNext()) != null)
            {
                if (node is Aspose.Html.Dom.Element elem)
                {
                    string href = elem.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        Console.WriteLine(href);
                    }
                }
            }

            // Remove onclick attributes
            var elementsWithOnclick = document.QuerySelectorAll("[onclick]");
            for (int i = 0; i < elementsWithOnclick.Length; i++)
            {
                Aspose.Html.Dom.Element el = (Aspose.Html.Dom.Element)elementsWithOnclick[i];
                string val = el.GetAttribute("onclick");
                if (!string.IsNullOrEmpty(val))
                {
                    el.RemoveAttribute("onclick");
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"\nModified document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}