// Generate a consolidated reference list for all URLs used in the document and insert it.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p>Sample <a href='https://example.com'>link</a> and another <a href=\"https://contoso.com/page\">page</a>.</p></body></html>";

            // Load HTML document from string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
            {
                // Collect all URLs from anchor elements
                System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>();
                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href) && !urls.Contains(href))
                    {
                        urls.Add(href);
                    }
                }

                // Create a reference list (ul) and populate it with URLs
                Aspose.Html.Dom.Element ulElement = document.CreateElement("ul");
                foreach (string url in urls)
                {
                    Aspose.Html.Dom.Element liElement = document.CreateElement("li");
                    liElement.TextContent = url;
                    ulElement.AppendChild(liElement);
                }

                // Append the reference list to the body of the document
                Aspose.Html.Dom.Element bodyElement = document.Body;
                bodyElement.AppendChild(ulElement);

                // Ensure output directory exists
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                Directory.CreateDirectory(outputDir);

                // Save the modified document
                string outputPath = Path.Combine(outputDir, "document_with_references.html");
                document.Save(outputPath);
                Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}