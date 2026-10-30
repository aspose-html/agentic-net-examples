// Select all paragraph elements using a CSS selector and iterate through them to extract plain text.

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
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<p>First paragraph.</p>" +
                                 "<div><p>Second paragraph inside a div.</p></div>" +
                                 "<p>Third paragraph.</p>" +
                                 "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("p");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string text = element.TextContent;
                System.Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}