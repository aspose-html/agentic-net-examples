// Extract all heading elements and assign incremental IDs for anchor linking within the document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with headings
            string htmlContent = @"
                <html>
                <head><title>Sample Document</title></head>
                <body>
                    <h1>First Heading</h1>
                    <p>Some paragraph.</p>
                    <h2>Second Heading</h2>
                    <h3>Third Heading</h3>
                    <h2>Another Second Heading</h2>
                </body>
                </html>";

            // Load document from inline HTML
            using (HTMLDocument doc = new HTMLDocument(htmlContent, "about:blank"))
            {
                var body = doc.Body;

                // Create a UL element for the table of contents
                var ul = (HTMLElement)doc.CreateElement("ul");

                int headingCounter = 1;
                string[] headingTags = new[] { "h1", "h2", "h3", "h4", "h5", "h6" };

                foreach (var tag in headingTags)
                {
                    HTMLCollection headings = doc.GetElementsByTagName(tag);
                    for (int i = 0; i < headings.Length; i++)
                    {
                        var heading = (HTMLHeadingElement)headings[i];
                        string id = "heading-" + headingCounter;

                        // Assign incremental ID to the heading
                        heading.SetAttribute("id", id);

                        // Create list item with anchor linking to the heading
                        var li = (HTMLElement)doc.CreateElement("li");
                        var a = (HTMLAnchorElement)doc.CreateElement("a");
                        a.SetAttribute("href", "#" + id);
                        a.AppendChild(doc.CreateTextNode(heading.TextContent));
                        li.AppendChild(a);
                        ul.AppendChild(li);

                        headingCounter++;
                    }
                }

                // Insert the UL at the beginning of the body
                var firstChild = body.FirstChild;
                if (firstChild != null)
                    body.InsertBefore(ul, firstChild);
                else
                    body.AppendChild(ul);

                // Save the modified document
                string outputPath = "output.html";
                doc.Save(outputPath);
                Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}