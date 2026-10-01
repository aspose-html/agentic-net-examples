// Use QuerySelectorAll to retrieve all elements with class "highlight" on the page.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<p class=\"highlight\">First highlighted text.</p>" +
                                 "<div class=\"highlight\">Second highlighted text.</div>" +
                                 "<span>Normal text.</span>" +
                                 "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "http://example.com");

            var nodes = document.QuerySelectorAll(".highlight");

            for (int i = 0; i < nodes.Length; i++)
            {
                Aspose.Html.HTMLElement element = nodes[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    System.Console.WriteLine(element.InnerHTML);
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}