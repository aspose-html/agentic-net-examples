// Generate a list of all external resource URLs referenced in a page using XPath and save to CSV.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the input HTML file and the output CSV file
            string htmlPath = "input.html";
            string csvPath = "resources.csv";

            // Load the HTML document
            HTMLDocument doc = new HTMLDocument(htmlPath);

            // Select all elements that have either a src or href attribute
            IXPathResult result = doc.Evaluate("//*[@src or @href]",
                                               doc,
                                               doc.CreateNSResolver(doc),
                                               XPathResultType.Any,
                                               null);

            var urls = new List<string>();
            Node node;
            // Iterate over the selected nodes
            while ((node = result.IterateNext()) != null)
            {
                Element element = (Element)node;
                string url = element.GetAttribute("src");
                if (string.IsNullOrEmpty(url))
                {
                    url = element.GetAttribute("href");
                }

                if (!string.IsNullOrEmpty(url))
                {
                    urls.Add(url);
                }
            }

            // Write the collected URLs to a CSV file (one URL per line)
            using (var writer = new StreamWriter(csvPath))
            {
                foreach (var u in urls)
                {
                    writer.WriteLine(u);
                }
            }

            Console.WriteLine($"Extracted {urls.Count} URLs to '{csvPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}