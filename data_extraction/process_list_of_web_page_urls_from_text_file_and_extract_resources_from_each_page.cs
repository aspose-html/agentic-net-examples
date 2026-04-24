// Process a list of web page URLs from a text file and extract resources from each page.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the text file containing URLs (one per line)
            string urlListPath = "urls.txt";

            if (!File.Exists(urlListPath))
            {
                Console.WriteLine($"File not found: {urlListPath}");
                return;
            }

            // Read all URLs from the file
            IEnumerable<string> urls = File.ReadLines(urlListPath);

            foreach (string rawUrl in urls)
            {
                string url = rawUrl.Trim();
                if (string.IsNullOrEmpty(url))
                    continue;

                Console.WriteLine($"Processing: {url}");

                // Load the HTML document from the URL
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);

                // ---------- Extract Image URLs ----------
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        // Resolve relative URLs against the document's base URI
                        Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(src, document.BaseURI);
                        Console.WriteLine($"Image: {resolvedUrl}");
                    }
                }

                // ---------- Extract Script Source URLs ----------
                Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                    string src = scriptElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        Console.WriteLine($"Script: {src}");
                    }
                }

                // ---------- Extract Hyperlinks Inside Tables ----------
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
                for (int t = 0; t < tables.Length; t++)
                {
                    Aspose.Html.HTMLElement htmlTable = tables[t] as Aspose.Html.HTMLElement;
                    if (htmlTable == null)
                        continue;

                    Aspose.Html.Collections.HTMLCollection links = htmlTable.GetElementsByTagName("a");
                    for (int i = 0; i < links.Length; i++)
                    {
                        Aspose.Html.Dom.Element link = links[i];
                        string href = link.GetAttribute("href");
                        string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                        if (!string.IsNullOrEmpty(href))
                        {
                            Console.WriteLine($"Table Link: href=\"{href}\", text=\"{text}\"");
                        }
                    }
                }

                Console.WriteLine(); // Separator between pages
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}