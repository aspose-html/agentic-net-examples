// List all downloadable file links by filtering anchor hrefs with common file extensions.

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
            // Sample HTML content
            string htmlContent = @"
                <html>
                    <body>
                        <a href='files/report.pdf'>Report</a>
                        <a href='https://example.com/docs/manual.docx'>Manual</a>
                        <a href='images/photo.jpg'>Photo</a>
                        <a href='https://example.com/page.html'>Home</a>
                        <a href='/downloads/archive.zip'>Archive</a>
                    </body>
                </html>";

            // Load HTML document from string with a base URI
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Collection to store downloadable links
            List<string> downloadableLinks = new List<string>();

            // Common file extensions for downloadable content
            string[] fileExtensions = new string[]
            {
                ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".zip", ".rar",
                ".txt", ".csv", ".png", ".jpg", ".jpeg", ".gif",
                ".mp3", ".mp4", ".avi", ".mov"
            };

            // Get all anchor elements
            HTMLCollection anchors = document.GetElementsByTagName("a");

            for (int i = 0; i < anchors.Length; i++)
            {
                Element anchor = anchors[i] as Element;
                if (anchor == null)
                    continue;

                string href = anchor.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs against the document's base URI
                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                string urlString = resolvedUrl.ToString();

                // Check if the URL ends with any of the specified file extensions
                foreach (string ext in fileExtensions)
                {
                    if (urlString.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                    {
                        downloadableLinks.Add(urlString);
                        break;
                    }
                }
            }

            // Output the results
            Console.WriteLine("Downloadable file links found:");
            foreach (string link in downloadableLinks)
            {
                Console.WriteLine(link);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}