// Generate a table of contents based on heading hierarchy and insert it at the top.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            string outputDir = System.IO.Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir) && !System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            var doc = new Aspose.Html.HTMLDocument();
            var body = doc.Body;

            // Sample headings
            var h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            h1.SetAttribute("id", "heading1");
            h1.AppendChild(doc.CreateTextNode("Chapter 1"));
            body.AppendChild(h1);

            var h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            h2.SetAttribute("id", "heading2");
            h2.AppendChild(doc.CreateTextNode("Section 1.1"));
            body.AppendChild(h2);

            var h2b = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            h2b.SetAttribute("id", "heading3");
            h2b.AppendChild(doc.CreateTextNode("Section 1.2"));
            body.AppendChild(h2b);

            var h3 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h3");
            h3.SetAttribute("id", "heading4");
            h3.AppendChild(doc.CreateTextNode("Subsection 1.2.1"));
            body.AppendChild(h3);

            // Generate Table of Contents
            var headings = doc.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
            var ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

            for (int i = 0; i < headings.Length; i++)
            {
                var heading = (Aspose.Html.HTMLElement)headings[i];
                string tag = heading.TagName.ToLower();
                int level = int.Parse(tag.Substring(1));

                var li = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                li.SetAttribute("style", "margin-left:" + ((level - 1) * 20) + "px;");

                var a = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
                string id = heading.GetAttribute("id");
                a.SetAttribute("href", "#" + id);
                a.AppendChild(doc.CreateTextNode(heading.TextContent.Trim()));

                li.AppendChild(a);
                ul.AppendChild(li);
            }

            var firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            doc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}