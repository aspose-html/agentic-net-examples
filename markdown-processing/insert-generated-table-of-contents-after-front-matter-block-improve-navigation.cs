// Insert a generated table of contents after the front‑matter block to improve navigation.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;

            // Front‑matter comment
            Aspose.Html.Dom.Comment frontMatter = doc.CreateComment(" Front Matter ");
            body.AppendChild(frontMatter);

            // First heading (h1)
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            h1.SetAttribute("id", "section1");
            h1.AppendChild(doc.CreateTextNode("Section 1"));
            body.AppendChild(h1);

            // Second heading (h2)
            Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            h2.SetAttribute("id", "section2");
            h2.AppendChild(doc.CreateTextNode("Section 2"));
            body.AppendChild(h2);

            // Table of contents (ul)
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

            // TOC entry for Section 1
            Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            Aspose.Html.HTMLAnchorElement a1 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a1.SetAttribute("href", "#section1");
            a1.AppendChild(doc.CreateTextNode("Section 1"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            // TOC entry for Section 2
            Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            Aspose.Html.HTMLAnchorElement a2 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a2.SetAttribute("href", "#section2");
            a2.AppendChild(doc.CreateTextNode("Section 2"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            // Insert TOC after front‑matter comment
            Aspose.Html.Dom.Node next = frontMatter.NextSibling;
            if (next != null)
                body.InsertBefore(ul, next);
            else
                body.AppendChild(ul);

            // Save the document
            string outputPath = "output.html";
            doc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}