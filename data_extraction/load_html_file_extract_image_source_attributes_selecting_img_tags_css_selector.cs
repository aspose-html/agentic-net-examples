// Load an HTML file and extract image source attributes by selecting img tags with a CSS selector.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            HTMLDocument document = new HTMLDocument(htmlPath);
            HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Element img in images)
            {
                string src = img.GetAttribute("src");
                Console.WriteLine(src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}