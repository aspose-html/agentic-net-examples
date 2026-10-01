// Append multiple list items to an unordered list element, then export the document as HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            string[] items = new string[] { "Item 1", "Item 2", "Item 3" };

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");
            body.AppendChild(ul);

            foreach (string itemText in items)
            {
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                Aspose.Html.Dom.Text textNode = document.CreateTextNode(itemText);
                li.AppendChild(textNode);
                ul.AppendChild(li);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}