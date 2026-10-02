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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Title 1</h1><h2>Subtitle</h2><h3>Section</h3></body></html>";
            // Load document from string (use two-argument constructor)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
            HTMLElement body = document.Body;

            // Create a list to hold anchor links
            HTMLElement ul = (HTMLElement)document.CreateElement("ul");

            int counter = 1;
            string[] headingTags = new string[] { "h1", "h2", "h3", "h4", "h5", "h6" };

            foreach (string tag in headingTags)
            {
                HTMLCollection headings = document.GetElementsByTagName(tag);
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLHeadingElement heading = (HTMLHeadingElement)headings[i];
                    string id = "heading" + counter;
                    heading.SetAttribute("id", id);

                    // Create list item with anchor linking to the heading
                    HTMLElement li = (HTMLElement)document.CreateElement("li");
                    HTMLAnchorElement a = (HTMLAnchorElement)document.CreateElement("a");
                    a.SetAttribute("href", "#" + id);
                    a.AppendChild(document.CreateTextNode(heading.TextContent));
                    li.AppendChild(a);
                    ul.AppendChild(li);

                    counter++;
                }
            }

            // Insert the list at the beginning of the body
            Node firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}