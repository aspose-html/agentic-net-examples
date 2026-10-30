// Navigate from the document element to the head section and list all linked stylesheet URLs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style1.css\"><link rel=\"stylesheet\" href=\"style2.css\"><link rel=\"icon\" href=\"favicon.ico\"></head><body><p>Hello World</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Navigate from the document element to the head section
            Aspose.Html.Dom.Element htmlElement = document.DocumentElement;
            Aspose.Html.Collections.HTMLCollection headCollection = htmlElement.GetElementsByTagName("head");
            if (headCollection.Length == 0)
            {
                Console.WriteLine("No <head> element found.");
                return;
            }
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)headCollection[0];

            // List all linked stylesheet URLs
            Aspose.Html.Collections.HTMLCollection linkElements = head.GetElementsByTagName("link");
            for (int i = 0; i < linkElements.Length; i++)
            {
                Aspose.Html.Dom.Element link = (Aspose.Html.Dom.Element)linkElements[i];
                string rel = link.GetAttribute("rel");
                if (string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase))
                {
                    string href = link.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        Console.WriteLine(href);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}