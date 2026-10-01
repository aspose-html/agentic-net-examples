// Load an HTML document, replace all anchor href attributes with absolute URLs, and save changes.

using System;
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
            string outputPath = "output.html";

            // Create a minimal HTML file with relative links
            string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                "<a href=\"page1.html\">Page 1</a> " +
                                "<a href=\"/page2.html\">Page 2</a> " +
                                "<a href=\"https://example.com/page3.html\">Page 3</a>" +
                                "</body></html>";
            File.WriteAllText(inputPath, sampleHtml);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all anchor elements
            HTMLCollection links = document.GetElementsByTagName("a");

            // Resolve each href to an absolute URL
            for (int i = 0; i < links.Length; i++)
            {
                Aspose.Html.Dom.Element link = links[i];
                string href = link.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Use the document's base URI to resolve relative URLs
                string baseUriString = document.BaseURI ?? "";
                Uri baseUri = new Uri(baseUriString, UriKind.RelativeOrAbsolute);
                Uri resolvedUri = new Uri(baseUri, href);
                link.SetAttribute("href", resolvedUri.ToString());
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}