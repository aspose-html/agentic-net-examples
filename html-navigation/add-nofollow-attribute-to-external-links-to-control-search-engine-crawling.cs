// Add a nofollow attribute to external links to control search engine crawling.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                 "<a href=\"https://example.com\">External Link</a>" +
                                 "<a href=\"/local/page.html\">Internal Link</a>" +
                                 "</body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get all anchor elements
                HTMLCollection links = document.GetElementsByTagName("a");
                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element linkElement = (Aspose.Html.Dom.Element)links[i];
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Add rel="nofollow" to external links (starting with http:// or https://)
                    if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        linkElement.SetAttribute("rel", "nofollow");
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Modified file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}