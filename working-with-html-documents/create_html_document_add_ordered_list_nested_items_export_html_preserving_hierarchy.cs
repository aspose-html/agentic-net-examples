// Create an HTML document, add an ordered list with nested items, and export to HTML preserving hierarchy.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Output file path
                string outputPath = "ordered_list.html";

                // Create a new empty HTML document
                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

                // Get the body element
                Aspose.Html.HTMLElement body = doc.Body;

                // Create the top‑level ordered list (<ol>)
                Aspose.Html.HTMLElement ol = (Aspose.Html.HTMLElement)doc.CreateElement("ol");

                // First list item (<li>) with nested ordered list
                Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                Aspose.Html.Dom.Text textLi1 = doc.CreateTextNode("Item 1");
                li1.AppendChild(textLi1);

                // Nested ordered list inside the first item
                Aspose.Html.HTMLElement nestedOl = (Aspose.Html.HTMLElement)doc.CreateElement("ol");
                Aspose.Html.HTMLElement nestedLi = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                Aspose.Html.Dom.Text nestedText = doc.CreateTextNode("Nested Item 1");
                nestedLi.AppendChild(nestedText);
                nestedOl.AppendChild(nestedLi);

                // Append the nested list to the first list item
                li1.AppendChild(nestedOl);

                // Second top‑level list item
                Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                Aspose.Html.Dom.Text textLi2 = doc.CreateTextNode("Item 2");
                li2.AppendChild(textLi2);

                // Assemble the ordered list hierarchy
                ol.AppendChild(li1);
                ol.AppendChild(li2);

                // Add the ordered list to the document body
                body.AppendChild(ol);

                // Save the HTML document to a file
                doc.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}