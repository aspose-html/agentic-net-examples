// Extract all email addresses from a webpage by selecting anchor tags with href containing "mailto:".

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace EmailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // URL of the web page to process
                string url = "https://example.com";

                // Load the HTML document from the specified URL
                HTMLDocument document = new HTMLDocument(url);

                // Get all anchor (<a>) elements in the document
                HTMLCollection anchorElements = document.GetElementsByTagName("a");

                // List to store extracted email addresses
                List<string> emails = new List<string>();

                // Iterate over each anchor element
                for (int i = 0; i < anchorElements.Length; i++)
                {
                    // Cast the collection item to a DOM element
                    Element anchor = (Element)anchorElements[i];

                    // Retrieve the href attribute value
                    string href = anchor.GetAttribute("href");

                    // Check if href is a mailto link
                    if (!string.IsNullOrEmpty(href) && href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                    {
                        // Extract the email address part (remove "mailto:")
                        string email = href.Substring("mailto:".Length).Trim();

                        // Add to the result list if not empty
                        if (!string.IsNullOrEmpty(email))
                        {
                            emails.Add(email);
                        }
                    }
                }

                // Output the extracted email addresses
                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}