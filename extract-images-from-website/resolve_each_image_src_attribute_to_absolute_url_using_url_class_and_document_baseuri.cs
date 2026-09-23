// Resolve each image src attribute to an absolute URL using Url class and document BaseURI.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><head><base href='https://example.com/'></head><body><img src='images/pic.png' /><img src='https://other.com/img.jpg' /></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                string src = imageElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;
                Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                Console.WriteLine(absoluteUrl.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}