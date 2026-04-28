// Extract the value of the author meta tag and store it for content attribution.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            HTMLDocument document = new HTMLDocument(url);
            HTMLCollection metaElements = document.GetElementsByTagName("meta");
            string author = null;
            for (int i = 0; i < metaElements.Length; i++)
            {
                Element meta = (Element)metaElements[i];
                string name = meta.GetAttribute("name");
                if (!string.IsNullOrEmpty(name) && name.Equals("author", StringComparison.OrdinalIgnoreCase))
                {
                    author = meta.GetAttribute("content");
                    break;
                }
            }
            Console.WriteLine(author ?? "Author meta tag not found");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}