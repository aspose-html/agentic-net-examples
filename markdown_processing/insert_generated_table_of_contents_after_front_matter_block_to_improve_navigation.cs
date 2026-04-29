// Insert a generated table of contents after the front‑matter block to improve navigation.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);

            HTMLElement front = document.QuerySelector("#front-matter") as HTMLElement;

            HTMLElement tocNav = (HTMLElement)document.CreateElement("nav");
            HTMLElement ul = (HTMLElement)document.CreateElement("ul");
            tocNav.AppendChild(ul);

            string[] headingTags = new[] { "h1", "h2", "h3", "h4", "h5", "h6" };
            foreach (string tag in headingTags)
            {
                var headings = document.GetElementsByTagName(tag);
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement heading = headings[i] as HTMLElement;
                    if (heading == null) continue;

                    string id = heading.GetAttribute("id");
                    if (string.IsNullOrEmpty(id))
                    {
                        id = "heading-" + Guid.NewGuid().ToString("N");
                        heading.SetAttribute("id", id);
                    }

                    HTMLElement li = (HTMLElement)document.CreateElement("li");
                    HTMLElement a = (HTMLElement)document.CreateElement("a");
                    a.SetAttribute("href", "#" + id);
                    Text linkText = document.CreateTextNode(heading.TextContent);
                    a.AppendChild(linkText);
                    li.AppendChild(a);
                    ul.AppendChild(li);
                }
            }

            if (front != null && front.ParentNode != null)
            {
                Node next = front.NextSibling;
                if (next != null)
                {
                    front.ParentNode.InsertBefore(tocNav, next);
                }
                else
                {
                    front.ParentNode.AppendChild(tocNav);
                }
            }
            else
            {
                document.Body.AppendChild(tocNav);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}