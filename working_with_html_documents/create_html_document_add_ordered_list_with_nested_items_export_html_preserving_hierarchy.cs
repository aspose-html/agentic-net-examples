// Create an HTML document, add an ordered list with nested items, and export to HTML preserving hierarchy.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "ordered_list.html";
            HTMLDocument document = new HTMLDocument();
            HTMLElement body = document.Body;

            HTMLElement ol = (HTMLElement)document.CreateElement("ol");
            body.AppendChild(ol);

            HTMLElement li1 = (HTMLElement)document.CreateElement("li");
            li1.AppendChild(document.CreateTextNode("Item 1"));
            ol.AppendChild(li1);

            HTMLElement subOl1 = (HTMLElement)document.CreateElement("ol");
            li1.AppendChild(subOl1);

            HTMLElement subLi1 = (HTMLElement)document.CreateElement("li");
            subLi1.AppendChild(document.CreateTextNode("Subitem 1.1"));
            subOl1.AppendChild(subLi1);

            HTMLElement subLi2 = (HTMLElement)document.CreateElement("li");
            subLi2.AppendChild(document.CreateTextNode("Subitem 1.2"));
            subOl1.AppendChild(subLi2);

            HTMLElement li2 = (HTMLElement)document.CreateElement("li");
            li2.AppendChild(document.CreateTextNode("Item 2"));
            ol.AppendChild(li2);

            HTMLElement subOl2 = (HTMLElement)document.CreateElement("ol");
            li2.AppendChild(subOl2);

            HTMLElement subLi3 = (HTMLElement)document.CreateElement("li");
            subLi3.AppendChild(document.CreateTextNode("Subitem 2.1"));
            subOl2.AppendChild(subLi3);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}