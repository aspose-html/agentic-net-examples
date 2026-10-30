// Extract the text content of all list items within a navigation menu using a CSS selector.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><nav><ul><li>Home</li><li>About</li><li>Contact</li></ul></nav></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("nav li");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                System.Console.WriteLine(element.InnerHTML);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}