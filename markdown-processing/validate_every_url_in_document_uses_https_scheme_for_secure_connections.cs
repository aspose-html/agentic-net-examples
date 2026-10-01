// Validate that every URL in the document uses the HTTPS scheme for secure connections.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com/sample.html";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                System.Collections.Generic.List<string> insecureLinks = new System.Collections.Generic.List<string>();

                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Uri resolvedUri;
                    try
                    {
                        resolvedUri = new Uri(new Uri(document.BaseURI), href);
                    }
                    catch
                    {
                        // Skip malformed URLs
                        continue;
                    }

                    if (!resolvedUri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                        insecureLinks.Add(resolvedUri.ToString());
                    }
                }

                if (insecureLinks.Count == 0)
                {
                    Console.WriteLine("All links use HTTPS scheme.");
                }
                else
                {
                    Console.WriteLine("Links with non-HTTPS scheme found:");
                    foreach (string link in insecureLinks)
                    {
                        Console.WriteLine(link);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}