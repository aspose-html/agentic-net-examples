// Use CSS selectors to locate all video tags and retrieve their source URLs for further processing.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"
                <html>
                    <body>
                        <video src='https://example.com/video1.mp4' controls></video>
                        <video controls>
                            <source src='https://example.com/video2.webm' type='video/webm' />
                            <source src='https://example.com/video2.mp4' type='video/mp4' />
                        </video>
                    </body>
                </html>";

            // Load the HTML content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all <video> elements
            var videos = document.QuerySelectorAll("video");

            foreach (Aspose.Html.HTMLElement video in videos)
            {
                // Try to get src attribute directly on <video>
                string src = video.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine(src);
                }

                // Also check for <source> child elements
                var sources = video.QuerySelectorAll("source");
                foreach (Aspose.Html.HTMLElement source in sources)
                {
                    string sourceSrc = source.GetAttribute("src");
                    if (!string.IsNullOrEmpty(sourceSrc))
                    {
                        Console.WriteLine(sourceSrc);
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