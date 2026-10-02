// Use QuerySelectorAll to retrieve all elements with class "highlight" on the page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body>" +
                          "<p class='highlight'>First highlighted</p>" +
                          "<div class='highlight'>Second highlighted</div>" +
                          "<span>Not highlighted</span>" +
                          "</body></html>";

            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var elements = document.QuerySelectorAll(".highlight");

            for (int i = 0; i < elements.Length; i++)
            {
                var element = (Aspose.Html.HTMLElement)elements[i];
                System.Console.WriteLine(element.InnerHTML);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}