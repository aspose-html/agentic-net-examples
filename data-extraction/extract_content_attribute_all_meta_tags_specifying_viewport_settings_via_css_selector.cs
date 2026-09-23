// Extract the content attribute of all meta tags that specify viewport settings via CSS selector.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head>" +
                          "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
                          "<meta name=\"viewport\" content=\"height=600\">" +
                          "<title>Sample</title></head><body></body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("meta[name=viewport]");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string content = element.GetAttribute("content");
                Console.WriteLine(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}