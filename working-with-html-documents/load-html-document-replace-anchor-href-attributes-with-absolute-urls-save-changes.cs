// Load an HTML document, replace all anchor href attributes with absolute URLs, and save changes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                    "<a href=\"page1.html\">Relative Link</a> " +
                                    "<a href=\"https://example.com/absolute\">Absolute Link</a>" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Replace all anchor href attributes with absolute URLs
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                linkElement.SetAttribute("href", resolvedUrl.ToString());
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}