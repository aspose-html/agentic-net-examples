// Create an HTML document, add an ordered list with nested items, and export to HTML preserving hierarchy.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "ordered_list.html";

            // Create a new HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Create the top-level ordered list
            Aspose.Html.HTMLElement ol = (Aspose.Html.HTMLElement)doc.CreateElement("ol");

            // Item 1
            Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            li1.AppendChild(doc.CreateTextNode("Item 1"));
            ol.AppendChild(li1);

            // Item 2 with nested ordered list
            Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            li2.AppendChild(doc.CreateTextNode("Item 2"));

            Aspose.Html.HTMLElement nestedOl = (Aspose.Html.HTMLElement)doc.CreateElement("ol");

            Aspose.Html.HTMLElement nestedLi1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            nestedLi1.AppendChild(doc.CreateTextNode("Subitem 2.1"));
            nestedOl.AppendChild(nestedLi1);

            Aspose.Html.HTMLElement nestedLi2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            nestedLi2.AppendChild(doc.CreateTextNode("Subitem 2.2"));
            nestedOl.AppendChild(nestedLi2);

            li2.AppendChild(nestedOl);
            ol.AppendChild(li2);

            // Item 3
            Aspose.Html.HTMLElement li3 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            li3.AppendChild(doc.CreateTextNode("Item 3"));
            ol.AppendChild(li3);

            // Append the ordered list to the body
            body.AppendChild(ol);

            // Save the document preserving hierarchy
            doc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}