// Load an HTML page from a URL using Aspose.HTML's HtmlDocument class.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            System.String url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
            {
                System.String html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : System.String.Empty;
                System.Console.WriteLine(html);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}