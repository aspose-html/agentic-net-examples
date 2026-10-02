// Extract email addresses from mailto links and compile them into a plain‑text list.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href=\"mailto:john@example.com\">John</a> " +
                                 "<a href=\"mailto:jane.doe@example.org?subject=Hello\">Jane</a> " +
                                 "<a href=\"https://example.com\">Link</a>" +
                                 "</body></html>";

            // Load HTML from string using two-argument constructor
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            List<string> emailList = new List<string>();

            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                if (href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                {
                    string emailPart = href.Substring(7);
                    int queryIndex = emailPart.IndexOf('?');
                    if (queryIndex >= 0)
                        emailPart = emailPart.Substring(0, queryIndex);
                    emailPart = emailPart.Trim();

                    if (!string.IsNullOrEmpty(emailPart) && !emailList.Contains(emailPart))
                        emailList.Add(emailPart);
                }
            }

            Console.WriteLine("Extracted email addresses:");
            foreach (string email in emailList)
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