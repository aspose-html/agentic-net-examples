// Use CSS selectors to locate all video tags and retrieve their source URLs for further processing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<video src='video1.mp4'></video>" +
                          "<video><source src='video2.webm' type='video/webm'></video>" +
                          "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var videos = document.QuerySelectorAll("video");

            foreach (Aspose.Html.HTMLElement video in videos)
            {
                string src = video.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine(src);
                }
                else
                {
                    var sources = video.QuerySelectorAll("source");
                    foreach (Aspose.Html.HTMLElement source in sources)
                    {
                        string s = source.GetAttribute("src");
                        if (!string.IsNullOrEmpty(s))
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}