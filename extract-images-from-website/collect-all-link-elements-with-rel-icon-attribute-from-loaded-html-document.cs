// Collect all <link> elements with rel='icon' attribute from the loaded HTML document.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><link rel='icon' href='favicon.ico'><link rel='stylesheet' href='style.css'></head><body></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection linkElements = document.GetElementsByTagName("link");
                for (int i = 0; i < linkElements.Length; i++)
                {
                    Aspose.Html.Dom.Element link = linkElements[i];
                    string rel = link.GetAttribute("rel");
                    if (!string.IsNullOrEmpty(rel) && rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    {
                        string href = link.GetAttribute("href");
                        System.Console.WriteLine($"Icon href: {href}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}