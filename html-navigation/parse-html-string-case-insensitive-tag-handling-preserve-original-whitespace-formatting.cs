// Parse an HTML string with case‑insensitive tag handling and preserve original whitespace formatting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<DiV>   <p>Test</p>   </DiV>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("div");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                System.Console.WriteLine(element.TagName);
            }

            string outerHtml = document.DocumentElement.OuterHTML;
            System.Console.WriteLine("OuterHTML:");
            System.Console.WriteLine(outerHtml);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}