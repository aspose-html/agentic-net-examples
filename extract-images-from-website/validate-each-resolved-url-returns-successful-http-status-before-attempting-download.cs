// Validate that each resolved URL returns a successful HTTP status before attempting download.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a temporary HTML file with sample links
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlSample");
            Directory.CreateDirectory(tempDir);
            string htmlFilePath = Path.Combine(tempDir, "sample.html");
            string htmlContent = "<html><body>" +
                                 "<a href=\"https://example.com\">Valid Link</a>" +
                                 "<a href=\"https://nonexistent.invalid\">Invalid Link</a>" +
                                 "</body></html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlFilePath))
            {
                List<string> brokenLinks = new List<string>();

                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the URL relative to the document's base URI
                    Url resolvedUrl = new Url(href, document.BaseURI);
                    RequestMessage request = new RequestMessage(resolvedUrl);
                    ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        // Successful response – download the content
                        byte[] contentBytes = response.Content.ReadAsByteArray();
                        Console.WriteLine($"Downloaded {contentBytes.Length} bytes from {resolvedUrl}");
                    }
                    else
                    {
                        // Record broken link
                        brokenLinks.Add(resolvedUrl.ToString());
                        Console.WriteLine($"Failed to download {resolvedUrl}, status code: {(int)response.StatusCode}");
                    }
                }

                if (brokenLinks.Count > 0)
                {
                    Console.WriteLine("Broken links detected:");
                    foreach (string url in brokenLinks)
                    {
                        Console.WriteLine(url);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}