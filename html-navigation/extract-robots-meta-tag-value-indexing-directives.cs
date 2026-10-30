// Extract the value of the robots meta tag to determine indexing directives.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"robots\" content=\"noindex, nofollow\"></head><body></body></html>";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection metas = doc.GetElementsByTagName("meta");
            for (int i = 0; i < metas.Length; i++)
            {
                Aspose.Html.HTMLElement meta = (Aspose.Html.HTMLElement)metas[i];
                string name = meta.GetAttribute("name");
                if (!string.IsNullOrEmpty(name) && name.Equals("robots", StringComparison.OrdinalIgnoreCase))
                {
                    string content = meta.GetAttribute("content");
                    Console.WriteLine("Robots meta tag content: " + content);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}