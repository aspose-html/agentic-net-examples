// Extract the canonical link element href value for SEO analysis from the document.

using System;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the HTML page; can be passed as a command‑line argument
            string url = args.Length > 0 ? args[0] : "https://example.com";

            // Load the document from the specified URL
            var document = new HTMLDocument(url);

            // Retrieve all <link> elements in the document
            var linkElements = document.GetElementsByTagName("link");

            string canonicalHref = null;

            // Iterate through the collection to find the canonical link
            for (int i = 0; i < linkElements.Length; i++)
            {
                // Cast each item to HTMLElement
                var element = linkElements[i] as HTMLElement;
                if (element == null) continue;

                // Check if the rel attribute equals "canonical"
                string rel = element.GetAttribute("rel");
                if (rel != null && rel.Equals("canonical", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract the href attribute value
                    canonicalHref = element.GetAttribute("href");
                    break;
                }
            }

            // Output the result
            if (!string.IsNullOrEmpty(canonicalHref))
                Console.WriteLine("Canonical href: " + canonicalHref);
            else
                Console.WriteLine("Canonical link not found.");
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}