// Extract embedded video source URLs from iframe elements for the media cataloging.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><iframe src='video1.mp4'></iframe><iframe src='https://example.com/video2.mp4'></iframe></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
                Aspose.Html.Collections.HTMLCollection iframes = document.GetElementsByTagName("iframe");
                for (int i = 0; i < iframes.Length; i++)
                {
                    Aspose.Html.Dom.Element iframeElement = (Aspose.Html.Dom.Element)iframes[i];
                    string src = iframeElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;
                    Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                    System.Console.WriteLine(absoluteUrl.ToString());
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}