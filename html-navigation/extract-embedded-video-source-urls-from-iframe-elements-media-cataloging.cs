// Extract embedded video source URLs from iframe elements for the media cataloging.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><iframe src='https://example.com/video1'></iframe><iframe src='video2.mp4'></iframe></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection iframes = document.GetElementsByTagName("iframe");
            for (int i = 0; i < iframes.Length; i++)
            {
                Aspose.Html.Dom.Element iframe = (Aspose.Html.Dom.Element)iframes[i];
                string src = iframe.GetAttribute("src");
                if (string.IsNullOrEmpty(src)) continue;
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