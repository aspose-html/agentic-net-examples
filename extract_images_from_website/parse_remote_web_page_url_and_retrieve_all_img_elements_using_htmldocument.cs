// Parse a remote web page URL and retrieve all <img> elements using HtmlDocument.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

namespace ImageExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string pageUrl = "https://example.com";
                HTMLDocument document = new HTMLDocument(pageUrl);
                HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;
                    Url absoluteUrl = new Url(src, document.BaseURI);
                    Console.WriteLine(absoluteUrl.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}