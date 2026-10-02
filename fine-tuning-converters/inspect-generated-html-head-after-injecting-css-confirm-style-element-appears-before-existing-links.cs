// After injecting CSS, inspect the generated HTML head to confirm the style element appears before existing links.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"/></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            var firstLink = (Aspose.Html.HTMLElement)document.GetElementsByTagName("link").First();

            var style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253); }";

            head.InsertBefore(style, firstLink);

            string headContent = ((Aspose.Html.HTMLElement)head).InnerHTML;
            Console.WriteLine("Head content after injection:");
            Console.WriteLine(headContent);

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}