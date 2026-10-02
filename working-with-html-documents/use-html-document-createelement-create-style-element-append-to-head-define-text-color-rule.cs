// Use HTMLDocument.CreateElement to create a style element, append to head, and define a text color rule.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "p { color: red; }";
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            document.Save("output.html");
            Console.WriteLine("HTML file saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}