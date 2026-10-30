// Parse an HTML string with case‑insensitive tag handling and preserve original whitespace formatting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html>\n<html>\n  <body>\n    <Div>   Hello   </Div>\n  </body>\n</html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("div");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                Console.WriteLine($"Tag: {element.TagName}");
            }

            Console.WriteLine("OuterHTML with original whitespace:");
            Console.WriteLine(document.DocumentElement.OuterHTML);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}