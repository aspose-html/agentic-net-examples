// Extract email addresses from mailto links and compile them into a plain‑text list.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with mailto links
            string htmlContent = @"
                <html>
                    <body>
                        <a href=""mailto:alice@example.com"">Contact Alice</a>
                        <a href=""mailto:bob@example.org"">Contact Bob</a>
                        <a href=""https://example.com"">Visit Site</a>
                        <a href=""mailto:carol@example.net"">Contact Carol</a>
                    </body>
                </html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Collection to store extracted email addresses
            List<string> emailList = new List<string>();

            // Iterate over all link elements in the document
            HTMLCollection links = document.Links;
            foreach (Element linkElement in links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                if (href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                {
                    string email = href.Substring("mailto:".Length);
                    if (!string.IsNullOrEmpty(email) && !emailList.Contains(email))
                    {
                        emailList.Add(email);
                    }
                }
            }

            // Output the extracted email addresses as a plain‑text list
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