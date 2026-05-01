// Create a document, add a link element referencing a stylesheet, and ensure stylesheet loads on render.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><p>Hello</p></body></html>";
            var document = new HTMLDocument(html, "http://example.com/");

            var link = (Element)document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", "style.css");

            var head = (HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(link);

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}