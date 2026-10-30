// Locate elements by class name and apply an internal CSS rule for background-color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><div class='highlight'>Item 1</div><p class='highlight'>Paragraph</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = ".highlight { background-color: AliceBlue; }";
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);
            head.AppendChild(styleElement);

            document.Save("output.html");
            Console.WriteLine("HTML saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}