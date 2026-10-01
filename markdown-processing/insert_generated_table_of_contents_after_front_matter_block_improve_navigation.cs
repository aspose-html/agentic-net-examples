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
            Aspose.Html.Dom.Element body = doc.Body;

            // Front‑matter block (comment)
            Aspose.Html.Dom.Comment frontMatter = doc.CreateComment(" Front Matter ");
            body.AppendChild(frontMatter);

            // Generate Table of Contents (ul)
            Aspose.Html.Dom.Element ul = doc.CreateElement("ul");

            // TOC entry for Section 1
            Aspose.Html.Dom.Element li1 = doc.CreateElement("li");
            Aspose.Html.Dom.Element a1 = doc.CreateElement("a");
            a1.SetAttribute("href", "#section1");
            a1.AppendChild(doc.CreateTextNode("Section 1"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            // TOC entry for Subsection 1
            Aspose.Html.Dom.Element li2 = doc.CreateElement("li");
            Aspose.Html.Dom.Element a2 = doc.CreateElement("a");
            a2.SetAttribute("href", "#subsection1");
            a2.AppendChild(doc.CreateTextNode("Subsection 1"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            // Insert TOC after the front‑matter block
            Aspose.Html.Dom.Node nextNode = frontMatter.NextSibling;
            if (nextNode != null)
                body.InsertBefore(ul, nextNode);
            else
                body.AppendChild(ul);

            // Add headings referenced by the TOC
            Aspose.Html.Dom.Element h1 = doc.CreateElement("h1");
            h1.SetAttribute("id", "section1");
            h1.AppendChild(doc.CreateTextNode("Section 1"));
            body.AppendChild(h1);

            Aspose.Html.Dom.Element h2 = doc.CreateElement("h2");
            h2.SetAttribute("id", "subsection1");
            h2.AppendChild(doc.CreateTextNode("Subsection 1"));
            body.AppendChild(h2);

            // Save the document
            string outputPath = "output.html";
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}