// Generate a table of contents based on heading hierarchy and insert it at the top.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;

            // Create first heading
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            h1.SetAttribute("id", "heading1");
            h1.AppendChild(doc.CreateTextNode("First Heading"));
            body.AppendChild(h1);

            // Create second heading
            Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            h2.SetAttribute("id", "heading2");
            h2.AppendChild(doc.CreateTextNode("Second Heading"));
            body.AppendChild(h2);

            // Build Table of Contents
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

            Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            Aspose.Html.HTMLAnchorElement a1 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a1.SetAttribute("href", "#heading1");
            a1.AppendChild(doc.CreateTextNode("First Heading"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            Aspose.Html.HTMLAnchorElement a2 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a2.SetAttribute("href", "#heading2");
            a2.AppendChild(doc.CreateTextNode("Second Heading"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            // Insert TOC at the top of the body
            var firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            // Save the document
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}