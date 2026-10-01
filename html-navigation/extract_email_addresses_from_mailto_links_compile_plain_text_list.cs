// Extract email addresses from mailto links and compile them into a plain‑text list.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file with mailto links
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<a href=\"mailto:alice@example.com\">Alice</a>" +
                                 "<a href=\"mailto:bob@example.org\">Bob</a>" +
                                 "<a href=\"https://example.com\">Website</a>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Select all <a> elements with href starting with "mailto:"
            var linkElements = document.QuerySelectorAll("a[href^='mailto:']");

            var emails = new List<string>();

            foreach (Aspose.Html.Dom.Element link in linkElements)
            {
                string href = link.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                const string mailtoPrefix = "mailto:";
                if (href.StartsWith(mailtoPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    string email = href.Substring(mailtoPrefix.Length);
                    emails.Add(email);
                }
            }

            // Output the extracted email addresses
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