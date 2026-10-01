// Add a custom data attribute to list nodes indicating whether they are ordered or unordered.

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;

            var ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");
            ul.SetAttribute("data-list-type", "unordered");

            var li1 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li1.AppendChild(document.CreateTextNode("Item 1"));
            ul.AppendChild(li1);

            var li2 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li2.AppendChild(document.CreateTextNode("Item 2"));
            ul.AppendChild(li2);

            body.AppendChild(ul);

            var ol = (Aspose.Html.HTMLElement)document.CreateElement("ol");
            ol.SetAttribute("data-list-type", "ordered");

            var li3 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li3.AppendChild(document.CreateTextNode("First"));
            ol.AppendChild(li3);

            var li4 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li4.AppendChild(document.CreateTextNode("Second"));
            ol.AppendChild(li4);

            body.AppendChild(ol);

            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}