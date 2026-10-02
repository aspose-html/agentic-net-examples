// Validate that every URL in the document uses the HTTPS scheme for secure connections.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;
using Aspose.Html.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://www.example.com";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                System.Collections.Generic.List<string> nonHttpsLinks = new System.Collections.Generic.List<string>();

                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                    System.Uri uri = new System.Uri(resolvedUrl.ToString());

                    if (!uri.Scheme.Equals(System.Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
                    {
                        nonHttpsLinks.Add(uri.ToString());
                    }
                }

                if (nonHttpsLinks.Count == 0)
                {
                    System.Console.WriteLine("All links use HTTPS.");
                }
                else
                {
                    System.Console.WriteLine("Links not using HTTPS:");
                    foreach (string link in nonHttpsLinks)
                    {
                        System.Console.WriteLine(link);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}