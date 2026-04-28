// Load multiple HTML documents concurrently using asynchronous methods and combine their body contents into one file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;

namespace AsposeHtmlConcurrentLoad
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // URLs of the HTML documents to load
                var urls = new List<string>
                {
                    "https://example.com/page1.html",
                    "https://example.com/page2.html",
                    "https://example.com/page3.html"
                };

                // Start loading all documents concurrently
                var loadTasks = urls.Select(async url =>
                {
                    var doc = new HTMLDocument();
                    await doc.NavigateAsync(url, CancellationToken.None);
                    // Return the inner HTML of the <body> element
                    return doc.Body.InnerHTML;
                }).ToList();

                // Wait for all loads to finish and collect body contents
                var bodies = await Task.WhenAll(loadTasks);

                // Combine all body contents into a single HTML string
                string combinedBody = string.Join("\n", bodies);
                string combinedHtml = $"<html><body>{combinedBody}</body></html>";

                // Create a new document from the combined HTML and save it
                var combinedDoc = new HTMLDocument(combinedHtml, string.Empty);
                combinedDoc.Save("combined.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}