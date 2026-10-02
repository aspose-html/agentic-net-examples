// Add a custom data attribute to list nodes indicating whether they are ordered or unordered.

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument();
            var body = document.Body;

            var h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            h1.SetAttribute("id", "title");
            h1.AppendChild(document.CreateTextNode("Sample Document"));
            body.AppendChild(h1);

            var h2 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h2");
            h2.SetAttribute("id", "subtitle");
            h2.AppendChild(document.CreateTextNode("List Example"));
            body.AppendChild(h2);

            var ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");
            ul.SetAttribute("data-list-type", "unordered");

            var li1 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            var a1 = (Aspose.Html.HTMLAnchorElement)document.CreateElement("a");
            a1.SetAttribute("href", "https://example.com/1");
            a1.AppendChild(document.CreateTextNode("Item 1"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            var li2 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            var a2 = (Aspose.Html.HTMLAnchorElement)document.CreateElement("a");
            a2.SetAttribute("href", "https://example.com/2");
            a2.AppendChild(document.CreateTextNode("Item 2"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            var firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            var ol = (Aspose.Html.HTMLElement)document.CreateElement("ol");
            ol.SetAttribute("data-list-type", "ordered");

            var li3 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li3.AppendChild(document.CreateTextNode("Ordered Item 1"));
            ol.AppendChild(li3);

            var li4 = (Aspose.Html.HTMLElement)document.CreateElement("li");
            li4.AppendChild(document.CreateTextNode("Ordered Item 2"));
            ol.AppendChild(li4);

            body.AppendChild(ol);

            var outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}