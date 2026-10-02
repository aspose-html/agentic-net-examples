// Extract the canonical link element href value for SEO analysis from the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"canonical\" href=\"https://example.com/page.html\" /></head><body><p>Hello World</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection linkElements = document.GetElementsByTagName("link");
            for (int i = 0; i < linkElements.Length; i++)
            {
                Aspose.Html.Dom.Element link = linkElements[i];
                string rel = link.GetAttribute("rel");
                if (!string.IsNullOrEmpty(rel) && rel.Equals("canonical", StringComparison.OrdinalIgnoreCase))
                {
                    string href = link.GetAttribute("href");
                    Console.WriteLine($"Canonical href: {href}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}