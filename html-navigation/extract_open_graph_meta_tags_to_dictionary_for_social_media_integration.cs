// Extract Open Graph meta tags and output them as a dictionary for social media integration.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = @"<!DOCTYPE html>
<html>
<head>
    <meta property='og:title' content='Example Title'>
    <meta property='og:description' content='An example description.'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <title>Test</title>
</head>
<body></body>
</html>";

            using (HTMLDocument document = new HTMLDocument(html))
            {
                HTMLCollection metaCollection = document.GetElementsByTagName("meta");
                var ogTags = new Dictionary<string, string>();

                for (int i = 0; i < metaCollection.Length; i++)
                {
                    Element meta = metaCollection[i] as Element;
                    if (meta != null)
                    {
                        string property = meta.GetAttribute("property");
                        if (!string.IsNullOrEmpty(property) && property.StartsWith("og:"))
                        {
                            string content = meta.GetAttribute("content");
                            if (!string.IsNullOrEmpty(content))
                            {
                                ogTags[property] = content;
                            }
                        }
                    }
                }

                foreach (var kvp in ogTags)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}