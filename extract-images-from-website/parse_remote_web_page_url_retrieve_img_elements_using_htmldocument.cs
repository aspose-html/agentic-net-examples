// Parse a remote web page URL and retrieve all <img> elements using HtmlDocument.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string pageUrl = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                foreach (Aspose.Html.Dom.Element img in images)
                {
                    string src = img.GetAttribute("src");
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}