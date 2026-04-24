// Load an HTML page from a URL using Aspose.HTML's HtmlDocument class.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            string html = document.DocumentElement.OuterHTML;
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}