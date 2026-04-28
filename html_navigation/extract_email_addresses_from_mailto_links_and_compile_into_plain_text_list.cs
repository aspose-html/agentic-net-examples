// Extract email addresses from mailto links and compile them into a plain‑text list.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page to process
            string url = "https://example.com";

            // Create and load the HTML document
            HTMLDocument document = new HTMLDocument(url);

            // List to store extracted email addresses
            List<string> emailList = new List<string>();

            // Iterate over all anchor elements in the document
            foreach (Element linkElement in document.Links)
            {
                // Get the href attribute value
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Check if the link is a mailto link
                if (href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract the email part after "mailto:"
                    string email = href.Substring("mailto:".Length);

                    // Remove any query parameters (e.g., "?subject=...")
                    int queryIndex = email.IndexOf('?');
                    if (queryIndex >= 0)
                        email = email.Substring(0, queryIndex);

                    email = email.Trim();

                    // Add to list if not already present
                    if (!string.IsNullOrEmpty(email) && !emailList.Contains(email))
                        emailList.Add(email);
                }
            }

            // Output the collected email addresses as plain text
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