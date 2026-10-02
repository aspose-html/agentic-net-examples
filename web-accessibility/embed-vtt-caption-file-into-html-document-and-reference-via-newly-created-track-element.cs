// Embed a .vtt caption file into the HTML document and reference it via a newly created <track> element.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Video with Captions</title></head><body></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
            HTMLElement body = (HTMLElement)document.Body;

            // Create <video> element
            HTMLElement video = (HTMLElement)document.CreateElement("video");
            video.SetAttribute("controls", "controls");
            video.SetAttribute("width", "640");
            video.SetAttribute("height", "360");

            // Optional: add a <source> element for the video file
            HTMLElement source = (HTMLElement)document.CreateElement("source");
            source.SetAttribute("src", "sample.mp4");
            source.SetAttribute("type", "video/mp4");
            video.AppendChild(source);

            // Create <track> element referencing the .vtt file
            HTMLElement track = (HTMLElement)document.CreateElement("track");
            track.SetAttribute("kind", "captions");
            track.SetAttribute("src", "captions.vtt");
            track.SetAttribute("srclang", "en");
            track.SetAttribute("label", "English");
            track.SetAttribute("default", "default");
            video.AppendChild(track);

            // Append video to the document body
            body.AppendChild(video);

            // Create a sample .vtt caption file
            string vttContent = "WEBVTT\n\n00:00:00.000 --> 00:00:05.000\nHello, world!";
            File.WriteAllText("captions.vtt", vttContent);

            // Save the modified HTML document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}