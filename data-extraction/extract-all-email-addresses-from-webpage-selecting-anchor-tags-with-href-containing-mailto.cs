// Extract all email addresses from a webpage by selecting anchor tags with href containing "mailto:".

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<a href=\"mailto:john.doe@example.com\">John</a>" +
                          "<a href=\"mailto:jane.smith@example.org\">Jane</a>" +
                          "<a href=\"https://example.com\">Link</a>" +
                          "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.Collections.NodeList nodes = document.QuerySelectorAll("a[href^='mailto:']");

            foreach (Aspose.Html.Dom.Node node in nodes)
            {
                Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    string href = element.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href) && href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                    {
                        string email = href.Substring("mailto:".Length);
                        System.Console.WriteLine(email);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}