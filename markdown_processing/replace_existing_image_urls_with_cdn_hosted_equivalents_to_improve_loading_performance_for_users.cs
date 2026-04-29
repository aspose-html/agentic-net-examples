// Replace existing image URLs with CDN-hosted equivalents to improve loading performance for users.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string cdnBase = "https://cdn.example.com";

            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLCollection images = document.GetElementsByTagName("img");

            for (int i = 0; i < images.Length; i++)
            {
                Element imgElement = (Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                Url imageUrl = new Url(src, document.BaseURI);
                string absoluteUrl = imageUrl.ToString();

                Uri uri = new Uri(absoluteUrl);
                string newUrl = cdnBase + uri.PathAndQuery;

                imgElement.SetAttribute("src", newUrl);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}