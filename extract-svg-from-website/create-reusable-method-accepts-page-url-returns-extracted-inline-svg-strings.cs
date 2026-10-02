// Create a reusable method that accepts a page URL and returns a list of extracted inline SVG strings.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            List<string> svgs = ExtractInlineSvgs(htmlPath);
            Console.WriteLine($"Extracted {svgs.Count} SVG(s).");
            foreach (string svg in svgs)
            {
                Console.WriteLine(svg);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static List<string> ExtractInlineSvgs(string pageUrl)
    {
        var document = new Aspose.Html.HTMLDocument(pageUrl);
        var svgs = document.GetElementsByTagName("svg");
        var result = new List<string>();
        for (int i = 0; i < svgs.Length; i++)
        {
            var svgElement = (Aspose.Html.HTMLElement)svgs[i];
            result.Add(svgElement.OuterHTML);
        }
        return result;
    }
}