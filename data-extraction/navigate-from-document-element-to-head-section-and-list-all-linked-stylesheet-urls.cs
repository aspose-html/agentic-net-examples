// Navigate from the document element to the head section and list all linked stylesheet URLs.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string html = "<!DOCTYPE html><html><head>" +
                          "<link rel=\"stylesheet\" href=\"styles/main.css\">" +
                          "<link rel=\"stylesheet\" href=\"https://example.com/theme.css\">" +
                          "<link rel=\"icon\" href=\"favicon.ico\">" +
                          "</head><body><p>Hello</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection headCollection = document.GetElementsByTagName("head");
            if (headCollection.Length == 0)
            {
                System.Console.WriteLine("No <head> element found.");
                return;
            }
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)headCollection[0];
            Aspose.Html.Collections.HTMLCollection linkElements = head.GetElementsByTagName("link");
            for (int i = 0; i < linkElements.Length; i++)
            {
                Aspose.Html.Dom.Element link = (Aspose.Html.Dom.Element)linkElements[i];
                string rel = link.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel) || !rel.Equals("stylesheet", System.StringComparison.OrdinalIgnoreCase))
                    continue;
                string href = link.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    System.Console.WriteLine(href);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}