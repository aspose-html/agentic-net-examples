// Generate a table of contents based on heading hierarchy and insert it at the top.

using System;

namespace AsposeHtmlTocExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputPath = "output.html";

                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
                var body = doc.Body;

                // Create headings
                Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
                h1.SetAttribute("id", "introduction");
                h1.AppendChild(doc.CreateTextNode("Introduction"));
                body.AppendChild(h1);

                Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
                h2.SetAttribute("id", "background");
                h2.AppendChild(doc.CreateTextNode("Background"));
                body.AppendChild(h2);

                Aspose.Html.HTMLHeadingElement h2b = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
                h2b.SetAttribute("id", "scope");
                h2b.AppendChild(doc.CreateTextNode("Scope"));
                body.AppendChild(h2b);

                Aspose.Html.HTMLHeadingElement h1b = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
                h1b.SetAttribute("id", "conclusion");
                h1b.AppendChild(doc.CreateTextNode("Conclusion"));
                body.AppendChild(h1b);

                // Build TOC
                Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

                void AddTocEntry(string id, string text)
                {
                    Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                    Aspose.Html.HTMLAnchorElement a = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
                    a.SetAttribute("href", "#" + id);
                    a.AppendChild(doc.CreateTextNode(text));
                    li.AppendChild(a);
                    ul.AppendChild(li);
                }

                AddTocEntry("introduction", "Introduction");
                AddTocEntry("background", "Background");
                AddTocEntry("scope", "Scope");
                AddTocEntry("conclusion", "Conclusion");

                // Insert TOC at top
                var firstChild = body.FirstChild;
                if (firstChild != null)
                    body.InsertBefore(ul, firstChild);
                else
                    body.AppendChild(ul);

                doc.Save(outputPath);
                Console.WriteLine("HTML document with TOC saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}