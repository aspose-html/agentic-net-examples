// Create a reusable method that accepts a URL and returns a list of absolute image URLs.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            List<string> imageUrls = GetImageUrls(url);
            Console.WriteLine("Found " + imageUrls.Count + " image(s):");
            foreach (string imgUrl in imageUrls)
            {
                Console.WriteLine(imgUrl);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static List<string> GetImageUrls(string url)
    {
        var result = new List<string>();
        HTMLDocument document = new HTMLDocument(url);
        HTMLCollection images = document.GetElementsByTagName("img");
        for (int i = 0; i < images.Length; i++)
        {
            Element imgElement = (Element)images[i];
            string src = imgElement.GetAttribute("src");
            if (string.IsNullOrEmpty(src))
                continue;
            Url absoluteUrl = new Url(src, document.BaseURI);
            result.Add(absoluteUrl.ToString());
        }
        return result;
    }
}