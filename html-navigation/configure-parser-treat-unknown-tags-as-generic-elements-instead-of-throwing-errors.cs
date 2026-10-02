// Configure the parser to treat unknown tags as generic elements instead of throwing errors.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><custom-tag>Test</custom-tag></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("custom-tag");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                System.Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}