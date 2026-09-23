// Create a reusable method that accepts a URL and returns a list of absolute image URLs.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string pageUrl = "https://example.com";
            List<string> imageUrls = GetAbsoluteImageUrls(pageUrl);
            foreach (string url in imageUrls)
            {
                Console.WriteLine(url);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static List<string> GetAbsoluteImageUrls(string pageUrl)
    {
        var result = new List<string>();
        var document = new Aspose.Html.HTMLDocument(pageUrl);
        var images = document.GetElementsByTagName("img");
        for (int i = 0; i < images.Length; i++)
        {
            var imgElement = (Aspose.Html.Dom.Element)images[i];
            string src = imgElement.GetAttribute("src");
            if (string.IsNullOrEmpty(src))
                continue;

            Uri baseUri;
            try
            {
                baseUri = new Uri(document.BaseURI);
            }
            catch
            {
                baseUri = new Uri(pageUrl);
            }

            Uri absoluteUri;
            if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                absoluteUri = new Uri(src);
            else
                absoluteUri = new Uri(baseUri, src);

            result.Add(absoluteUri.ToString());
        }
        return result;
    }
}