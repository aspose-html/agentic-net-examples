// Use CSS selectors to locate all video tags and retrieve their source URLs for further processing.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing video tags
            string html = @"<html><body>" +
                          "<video src='video1.mp4'></video>" +
                          "<video src='http://example.com/video2.mp4'></video>" +
                          "</body></html>";

            // Base URI for resolving relative URLs
            string baseUri = "http://example.com/";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);

            // Select all video elements using a CSS selector
            var videos = document.QuerySelectorAll("video");

            // Iterate over each video element and retrieve its source URL
            foreach (Aspose.Html.HTMLElement video in videos)
            {
                string src = video.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    // Resolve relative URLs to absolute URLs
                    Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                    Console.WriteLine(absoluteUrl.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}