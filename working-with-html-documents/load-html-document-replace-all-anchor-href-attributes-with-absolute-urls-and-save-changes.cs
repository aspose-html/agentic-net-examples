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
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                    "<a href=\"page1.html\">Page 1</a>" +
                                    "<a href=\"https://example.com/absolute\">Absolute Link</a>" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get all anchor elements
                HTMLCollection anchors = document.GetElementsByTagName("a");
                for (int i = 0; i < anchors.Length; i++)
                {
                    Element link = (Element)anchors[i];
                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // If href is already absolute, skip
                    if (Uri.IsWellFormedUriString(href, UriKind.Absolute))
                        continue;

                    // Resolve relative URL against the document's base URI or input file directory
                    string basePath = Path.GetDirectoryName(Path.GetFullPath(inputPath));
                    Uri baseUri = new Uri(basePath + Path.DirectorySeparatorChar);
                    Uri absoluteUri = new Uri(baseUri, href);
                    link.SetAttribute("href", absoluteUri.AbsoluteUri);
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}