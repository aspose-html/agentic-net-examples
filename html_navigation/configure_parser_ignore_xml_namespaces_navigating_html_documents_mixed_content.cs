// Configure the parser to ignore XML namespaces when navigating HTML documents containing mixed content.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg></body></html>";
            using var document = new HTMLDocument(html, "http://example.com");
            var elements = document.GetElementsByTagName("svg");
            for (int i = 0; i < elements.Length; i++)
            {
                var element = (Aspose.Html.Dom.Element)elements[i];
                Console.WriteLine(element.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}