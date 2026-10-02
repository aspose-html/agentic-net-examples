// Extract all meta description content and summarize its length for content quality checks.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta name=""description"" content=""This is a sample description for testing."">
    <meta name=""keywords"" content=""sample, test"">
    <meta name=""description"" content=""Another description meta tag."">
</head>
<body>
    <p>Hello World!</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLCollection metaElements = document.GetElementsByTagName("meta");
                List<string> descriptions = new List<string>();
                for (int i = 0; i < metaElements.Length; i++)
                {
                    HTMLElement element = metaElements[i] as HTMLElement;
                    if (element == null)
                        continue;

                    string nameAttr = element.GetAttribute("name");
                    if (string.IsNullOrEmpty(nameAttr))
                        continue;

                    if (nameAttr.Equals("description", StringComparison.OrdinalIgnoreCase))
                    {
                        string content = element.GetAttribute("content") ?? string.Empty;
                        descriptions.Add(content);
                        Console.WriteLine($"Description: \"{content}\"");
                        Console.WriteLine($"Length: {content.Length}");
                    }
                }

                int totalLength = 0;
                foreach (string desc in descriptions)
                {
                    totalLength += desc.Length;
                }

                Console.WriteLine($"Total number of description meta tags: {descriptions.Count}");
                Console.WriteLine($"Combined length of all descriptions: {totalLength}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}