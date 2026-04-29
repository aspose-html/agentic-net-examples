// Generate a consolidated reference list for all URLs used in the document and insert it.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL or local path
            string sourcePath = "input.html"; // replace with your source file or URL
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Collect all hyperlink URLs from the document
            List<string> urlList = new List<string>();
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs against the document's base URI
                Url resolvedUrl = new Url(href, document.BaseURI);
                urlList.Add(resolvedUrl.ToString());
            }

            // Build a reference list section
            Element div = document.CreateElement("div");
            Element heading = document.CreateElement("h2");
            heading.TextContent = "Consolidated References";
            div.AppendChild(heading);

            Element ul = document.CreateElement("ul");
            foreach (string url in urlList)
            {
                Element li = document.CreateElement("li");
                Element a = document.CreateElement("a");
                a.SetAttribute("href", url);
                a.TextContent = url;
                li.AppendChild(a);
                ul.AppendChild(li);
            }
            div.AppendChild(ul);

            // Insert the reference list at the end of the body
            document.Body.AppendChild(div);

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}