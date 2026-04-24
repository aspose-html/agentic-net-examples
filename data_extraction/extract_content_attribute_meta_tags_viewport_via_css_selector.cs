// Extract the content attribute of all meta tags that specify viewport settings via CSS selector.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            HTMLDocument document = new HTMLDocument(inputPath);
            var metaElements = document.QuerySelectorAll("meta[name='viewport']");
            foreach (HTMLElement element in metaElements)
            {
                if (element is HTMLMetaElement meta)
                {
                    Console.WriteLine(meta.Content);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}