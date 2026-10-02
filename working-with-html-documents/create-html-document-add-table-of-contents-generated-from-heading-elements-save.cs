// Create an HTML document, add a table of contents generated from heading elements, and save.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;

            // Create first heading (h1)
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            h1.SetAttribute("id", "section1");
            h1.AppendChild(doc.CreateTextNode("Section 1"));
            body.AppendChild(h1);

            // Create second heading (h2)
            Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            h2.SetAttribute("id", "subsection1");
            h2.AppendChild(doc.CreateTextNode("Subsection 1"));
            body.AppendChild(h2);

            // Create Table of Contents (ul)
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

            // TOC entry for h1
            Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            Aspose.Html.HTMLAnchorElement a1 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a1.SetAttribute("href", "#section1");
            a1.AppendChild(doc.CreateTextNode("Section 1"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            // TOC entry for h2
            Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            Aspose.Html.HTMLAnchorElement a2 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a2.SetAttribute("href", "#subsection1");
            a2.AppendChild(doc.CreateTextNode("Subsection 1"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            // Insert TOC at the beginning of the body
            Aspose.Html.Dom.Node firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            // Save the document
            doc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}