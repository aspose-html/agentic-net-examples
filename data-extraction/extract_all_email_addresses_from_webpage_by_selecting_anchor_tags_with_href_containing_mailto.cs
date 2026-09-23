// Extract all email addresses from a webpage by selecting anchor tags with href containing "mailto:".

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<a href=\"mailto:john@example.com\">John</a>" +
                          "<a href=\"mailto:jane.doe@example.org\">Jane</a>" +
                          "<a href=\"https://example.com\">Link</a>" +
                          "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            var elements = document.QuerySelectorAll("a[href^='mailto:']");

            List<string> emails = new List<string>();
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href) && href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                {
                    string email = href.Substring("mailto:".Length);
                    emails.Add(email);
                }
            }

            Console.WriteLine("Extracted email addresses:");
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}