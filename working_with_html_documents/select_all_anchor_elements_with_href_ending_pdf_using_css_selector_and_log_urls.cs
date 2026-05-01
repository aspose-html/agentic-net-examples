// Select all anchor elements with href ending in ".pdf" using CSS selector and log URLs.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com/page.html");

            // Select all anchor elements whose href ends with ".pdf"
            var elements = document.QuerySelectorAll("a[href$='.pdf']");

            // Log each matching URL
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    Console.WriteLine(href);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}