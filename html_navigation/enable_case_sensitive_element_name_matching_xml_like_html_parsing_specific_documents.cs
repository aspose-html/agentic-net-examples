// Enable case‑sensitive element name matching for XML‑like HTML parsing scenarios when processing specific documents.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<root><CustomTag>Value</CustomTag><customtag>Other</customtag></root>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, ""))
            {
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("CustomTag");
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                    Console.WriteLine(element.TagName);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}