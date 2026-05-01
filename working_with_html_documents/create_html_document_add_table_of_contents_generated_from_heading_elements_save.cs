// Create an HTML document, add a table of contents generated from heading elements, and save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace HtmlTocExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputPath = "output.html";
                HTMLDocument doc = new HTMLDocument();
                var body = doc.Body;

                var h1 = (HTMLHeadingElement)doc.CreateElement("h1");
                h1.SetAttribute("id", "section1");
                h1.AppendChild(doc.CreateTextNode("Section 1"));
                body.AppendChild(h1);

                var h2 = (HTMLHeadingElement)doc.CreateElement("h2");
                h2.SetAttribute("id", "section2");
                h2.AppendChild(doc.CreateTextNode("Section 2"));
                body.AppendChild(h2);

                var ul = (HTMLElement)doc.CreateElement("ul");

                var li1 = (HTMLElement)doc.CreateElement("li");
                var a1 = (HTMLAnchorElement)doc.CreateElement("a");
                a1.SetAttribute("href", "#section1");
                a1.AppendChild(doc.CreateTextNode("Section 1"));
                li1.AppendChild(a1);
                ul.AppendChild(li1);

                var li2 = (HTMLElement)doc.CreateElement("li");
                var a2 = (HTMLAnchorElement)doc.CreateElement("a");
                a2.SetAttribute("href", "#section2");
                a2.AppendChild(doc.CreateTextNode("Section 2"));
                li2.AppendChild(a2);
                ul.AppendChild(li2);

                var firstChild = body.FirstChild;
                if (firstChild != null)
                    body.InsertBefore(ul, firstChild);
                else
                    body.AppendChild(ul);

                doc.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}