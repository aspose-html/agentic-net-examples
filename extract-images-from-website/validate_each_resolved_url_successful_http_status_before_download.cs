// Validate that each resolved URL returns a successful HTTP status before attempting download.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";

            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<a href=\"https://www.example.com\">Example</a>" +
                                    "<a href=\"https://nonexistent.invalid\">Broken</a>" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                List<string> brokenLinks = new List<string>();

                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Url resolvedUrl = new Url(href, document.BaseURI);
                    RequestMessage request = new RequestMessage(resolvedUrl);
                    ResponseMessage response = document.Context.Network.Send(request);

                    if (!response.IsSuccess)
                    {
                        brokenLinks.Add(resolvedUrl.ToString());
                        Console.WriteLine($"Link failed: {resolvedUrl} Status: {(int)response.StatusCode}");
                    }
                    else
                    {
                        byte[] contentBytes = response.Content.ReadAsByteArray();
                        Console.WriteLine($"Link succeeded: {resolvedUrl} Size: {contentBytes.Length} bytes");
                    }
                }

                if (brokenLinks.Count == 0)
                {
                    Console.WriteLine("All links are valid.");
                }
                else
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