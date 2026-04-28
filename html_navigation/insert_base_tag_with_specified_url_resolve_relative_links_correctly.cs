// Insert a base tag with a specified URL to resolve relative links correctly.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string baseUrl = "https://example.com/";
            var document = new HTMLDocument("input.html");
            var baseElement = document.CreateElement("base");
            baseElement.SetAttribute("href", baseUrl);
            var heads = document.GetElementsByTagName("head");
            if (heads.Length > 0)
            {
                var head = (Element)heads[0];
                head.AppendChild(baseElement);
            }
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}