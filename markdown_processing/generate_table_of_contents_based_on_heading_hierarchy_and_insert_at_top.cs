// Generate a table of contents based on heading hierarchy and insert it at the top.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering;

namespace AsposeHtmlTocExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input and output HTML file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the existing HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Select all heading elements (h1‑h6)
                var headingNodes = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                // Create a <nav> element to hold the table of contents
                Element nav = document.CreateElement("nav");
                // Optional: add a heading for the TOC
                Element tocTitle = document.CreateElement("h2");
                tocTitle.AppendChild(document.CreateTextNode("Table of Contents"));
                nav.AppendChild(tocTitle);

                // Create the root <ul> list
                Element ulRoot = document.CreateElement("ul");
                nav.AppendChild(ulRoot);

                // Build TOC entries
                foreach (var node in headingNodes)
                {
                    // Cast to HTMLElement to access tag name and attributes
                    HTMLElement heading = (HTMLElement)node;
                    string tagName = heading.TagName.ToLower(); // e.g., "h2"
                    int level = int.Parse(tagName.Substring(1)); // 1‑6

                    // Ensure the heading has an id for linking
                    string id = heading.GetAttribute("id");
                    if (string.IsNullOrEmpty(id))
                    {
                        id = $"heading-{Guid.NewGuid():N}";
                        heading.SetAttribute("id", id);
                    }

                    // Create <li> and <a> elements
                    Element li = document.CreateElement("li");
                    // Indent according to heading level (optional styling)
                    li.SetAttribute("style", $"margin-left:{(level - 1) * 20}px;");

                    Element a = document.CreateElement("a");
                    a.SetAttribute("href", $"#{id}");
                    a.AppendChild(document.CreateTextNode(heading.TextContent.Trim()));

                    li.AppendChild(a);
                    ulRoot.AppendChild(li);
                }

                // Insert the TOC at the top of the body
                HTMLElement body = document.Body;
                Node firstChild = body.FirstChild;
                if (firstChild != null)
                {
                    body.InsertBefore(nav, firstChild);
                }
                else
                {
                    body.AppendChild(nav);
                }

                // Save the modified document
                document.Save(outputPath);
                Console.WriteLine($"Table of contents generated and saved to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}