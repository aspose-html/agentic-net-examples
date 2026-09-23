// Use CSS selectors to locate all video tags and retrieve their source URLs for further processing.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = @"<!DOCTYPE html><html><body>" +
                          "<video src='video1.mp4'></video>" +
                          "<video><source src='video2.webm' type='video/webm'></video>" +
                          "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);

            var videoElements = document.QuerySelectorAll("video");
            foreach (Aspose.Html.HTMLElement video in videoElements)
            {
                string src = video.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    System.Console.WriteLine(src);
                }

                Aspose.Html.Collections.HTMLCollection sourceElements = video.GetElementsByTagName("source");
                foreach (Aspose.Html.Dom.Element source in sourceElements)
                {
                    string sourceSrc = source.GetAttribute("src");
                    if (!string.IsNullOrEmpty(sourceSrc))
                    {
                        System.Console.WriteLine(sourceSrc);
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