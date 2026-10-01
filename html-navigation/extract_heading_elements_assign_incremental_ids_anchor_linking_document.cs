// Extract all heading elements and assign incremental IDs for anchor linking within the document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            using (HTMLDocument doc = new HTMLDocument())
            {
                // Sample headings
                var body = doc.Body;

                var h1 = (HTMLHeadingElement)doc.CreateElement("h1");
                h1.AppendChild(doc.CreateTextNode("First Heading"));
                body.AppendChild(h1);

                var h2 = (HTMLHeadingElement)doc.CreateElement("h2");
                h2.AppendChild(doc.CreateTextNode("Second Heading"));
                body.AppendChild(h2);

                var h3 = (HTMLHeadingElement)doc.CreateElement("h3");
                h3.AppendChild(doc.CreateTextNode("Third Heading"));
                body.AppendChild(h3);

                // Assign incremental IDs to all heading elements
                int idCounter = 1;
                string[] headingTags = { "h1", "h2", "h3", "h4", "h5", "h6" };
                foreach (var tag in headingTags)
                {
                    HTMLCollection collection = doc.GetElementsByTagName(tag);
                    for (int i = 0; i < collection.Length; i++)
                    {
                        var heading = collection[i] as HTMLHeadingElement;
                        if (heading != null)
                        {
                            string id = "heading" + idCounter++;
                            heading.SetAttribute("id", id);
                        }
                    }
                }

                // Create a list of anchor links to the headings
                var ul = (HTMLElement)doc.CreateElement("ul");
                foreach (var tag in headingTags)
                {
                    HTMLCollection collection = doc.GetElementsByTagName(tag);
                    for (int i = 0; i < collection.Length; i++)
                    {
                        var heading = collection[i] as HTMLHeadingElement;
                        if (heading != null)
                        {
                            string id = heading.GetAttribute("id");
                            var li = (HTMLElement)doc.CreateElement("li");
                            var a = (HTMLAnchorElement)doc.CreateElement("a");
                            a.SetAttribute("href", "#" + id);
                            a.AppendChild(doc.CreateTextNode(heading.TextContent));
                            li.AppendChild(a);
                            ul.AppendChild(li);
                        }
                    }
                }

                // Insert the list at the beginning of the body
                var firstChild = body.FirstChild;
                if (firstChild != null)
                    body.InsertBefore(ul, firstChild);
                else
                    body.AppendChild(ul);

                // Save the modified document
                string outputPath = "output.html";
                doc.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}