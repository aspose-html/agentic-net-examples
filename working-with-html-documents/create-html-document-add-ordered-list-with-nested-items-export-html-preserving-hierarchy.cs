// Create an HTML document, add an ordered list with nested items, and export to HTML preserving hierarchy.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;

            // Create the outer ordered list
            Aspose.Html.HTMLElement ol = (Aspose.Html.HTMLElement)document.CreateElement("ol");

            // First list item with nested ordered list
            Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li1.AppendChild(document.CreateTextNode("Item 1"));

            Aspose.Html.HTMLElement nestedOl = (Aspose.Html.HTMLElement)document.CreateElement("ol");

            Aspose.Html.HTMLElement nestedLi1 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            nestedLi1.AppendChild(document.CreateTextNode("Subitem 1.1"));
            nestedOl.AppendChild(nestedLi1);

            Aspose.Html.HTMLElement nestedLi2 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            nestedLi2.AppendChild(document.CreateTextNode("Subitem 1.2"));
            nestedOl.AppendChild(nestedLi2);

            li1.AppendChild(nestedOl);
            ol.AppendChild(li1);

            // Second list item
            Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li2.AppendChild(document.CreateTextNode("Item 2"));
            ol.AppendChild(li2);

            // Third list item with deeper nesting
            Aspose.Html.HTMLElement li3 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li3.AppendChild(document.CreateTextNode("Item 3"));

            Aspose.Html.HTMLElement nestedOl2 = (Aspose.Html.HTMLElement)document.CreateElement("ol");

            Aspose.Html.HTMLElement nestedLi3 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            nestedLi3.AppendChild(document.CreateTextNode("Subitem 3.1"));
            nestedOl2.AppendChild(nestedLi3);

            Aspose.Html.HTMLElement nestedLi4 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            nestedLi4.AppendChild(document.CreateTextNode("Subitem 3.2"));
            nestedOl2.AppendChild(nestedLi4);

            li3.AppendChild(nestedOl2);
            ol.AppendChild(li3);

            // Append the ordered list to the body
            body.AppendChild(ol);

            // Save the document preserving hierarchy
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}