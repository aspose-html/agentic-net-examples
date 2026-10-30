// Create a reusable method that accepts a page URL and returns a list of extracted inline SVG strings.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            List<string> svgs = ExtractInlineSvgs(url);
            Console.WriteLine($"Extracted {svgs.Count} inline SVG(s) from {url}.");
            for (int i = 0; i < svgs.Count; i++)
            {
                Console.WriteLine($"--- SVG {i + 1} ---");
                Console.WriteLine(svgs[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static List<string> ExtractInlineSvgs(string pageUrl)
    {
        var result = new List<string>();
        HTMLDocument document = new HTMLDocument(pageUrl);
        HTMLCollection svgs = document.GetElementsByTagName("svg");
        for (int i = 0; i < svgs.Length; i++)
        {
            var svgElement = (HTMLElement)svgs[i];
            string markup = svgElement.OuterHTML;
            result.Add(markup);
        }
        return result;
    }
}