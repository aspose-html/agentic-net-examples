// Configure the parser to treat unknown tags as generic elements instead of throwing errors.

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
            string htmlContent = "<html><body><custom-tag>Hello</custom-tag><div>World</div></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "");
            HTMLCollection elements = document.GetElementsByTagName("*");
            for (int i = 0; i < elements.Length; i++)
            {
                Element element = (Element)elements[i];
                Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}