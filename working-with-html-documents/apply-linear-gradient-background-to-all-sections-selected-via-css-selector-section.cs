// Apply a linear gradient background to all sections selected via CSS selector ".section".

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><div class='section'>Section 1</div><div class='section'>Section 2</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = ".section { background: linear-gradient(to right, red, blue); }";
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }
            head.AppendChild(styleElement);

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}