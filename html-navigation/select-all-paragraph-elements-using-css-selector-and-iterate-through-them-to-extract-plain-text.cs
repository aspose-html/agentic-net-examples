// Select all paragraph elements using a CSS selector and iterate through them to extract plain text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var elements = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                System.Console.WriteLine(element.TextContent);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}