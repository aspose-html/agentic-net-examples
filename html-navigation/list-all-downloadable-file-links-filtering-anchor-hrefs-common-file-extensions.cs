// List all downloadable file links by filtering anchor hrefs with common file extensions.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>" +
                          "<a href='https://example.com/file.pdf'>PDF</a>" +
                          "<a href='https://example.com/image.png'>Image</a>" +
                          "<a href='https://example.com/page.html'>Page</a>" +
                          "<a href='files/document.docx'>Doc</a>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                List<string> downloadableLinks = new List<string>();
                string[] extensions = new string[]
                {
                    ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".zip", ".rar",
                    ".png", ".jpg", ".jpeg", ".gif", ".txt", ".csv",
                    ".mp3", ".mp4", ".avi", ".mov"
                };

                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                    string lowerHref = resolvedUrl.ToString().ToLowerInvariant();

                    foreach (string ext in extensions)
                    {
                        if (lowerHref.EndsWith(ext))
                        {
                            downloadableLinks.Add(resolvedUrl.ToString());
                            break;
                        }
                    }
                }

                Console.WriteLine("Downloadable file links:");
                foreach (string link in downloadableLinks)
                {
                    Console.WriteLine(link);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}