// Extract the canonical link element href value for SEO analysis from the document.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content containing a canonical link
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""canonical"" href=""https://example.com/page"" />
    <title>Sample Page</title>
</head>
<body>
    <p>Hello, world!</p>
</body>
</html>";

            // Load the HTML document from the string (using a dummy base URI)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Retrieve all <link> elements
            Aspose.Html.Collections.HTMLCollection linkElements = document.GetElementsByTagName("link");

            string canonicalHref = null;

            for (int i = 0; i < linkElements.Length; i++)
            {
                Aspose.Html.HTMLElement link = linkElements[i] as Aspose.Html.HTMLElement;
                if (link == null)
                    continue;

                string rel = link.GetAttribute("rel");
                if (rel != null && rel.Equals("canonical", StringComparison.OrdinalIgnoreCase))
                {
                    canonicalHref = link.GetAttribute("href");
                    break;
                }
            }

            if (!string.IsNullOrEmpty(canonicalHref))
            {
                Console.WriteLine("Canonical href: " + canonicalHref);
            }
            else
            {
                Console.WriteLine("No canonical link found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}