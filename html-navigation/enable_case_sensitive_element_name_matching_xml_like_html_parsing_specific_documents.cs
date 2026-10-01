// Enable case‑sensitive element name matching for XML‑like HTML parsing scenarios when processing specific documents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<Root><Item>Value</Item></Root>";

            // Create a base URL required by the HTMLDocument constructor that accepts HTML string.
            Aspose.Html.Url baseUrl = new Aspose.Html.Url("about:blank");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUrl);

            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("Item");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                System.Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}