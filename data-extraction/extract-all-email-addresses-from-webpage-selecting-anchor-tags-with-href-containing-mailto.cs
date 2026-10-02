// Extract all email addresses from a webpage by selecting anchor tags with href containing "mailto:".

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                "<a href=\"mailto:john@example.com\">John</a>" +
                "<a href=\"mailto:jane.doe@example.org\">Jane</a>" +
                "<a href=\"https://example.com\">Website</a>" +
                "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var elements = document.QuerySelectorAll("a[href^='mailto:']");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href) && href.StartsWith("mailto:", System.StringComparison.OrdinalIgnoreCase))
                {
                    string email = href.Substring("mailto:".Length);
                    System.Console.WriteLine(email);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}