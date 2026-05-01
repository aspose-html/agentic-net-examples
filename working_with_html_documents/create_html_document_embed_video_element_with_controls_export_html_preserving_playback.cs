// Create an HTML document, embed a video element with controls, and export to HTML preserving playback.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset='utf-8'></head><body></body></html>";
            string baseUri = "";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Dom.Element video = document.CreateElement("video");
            video.SetAttribute("src", "sample.mp4");
            video.SetAttribute("controls", "controls");

            document.Body.AppendChild(video);

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}