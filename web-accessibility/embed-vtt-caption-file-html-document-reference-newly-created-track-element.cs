// Embed a .vtt caption file into the HTML document and reference it via a newly created <track> element.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML document from inline content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Ensure a sample VTT caption file exists
            string vttPath = "captions.vtt";
            if (!File.Exists(vttPath))
            {
                File.WriteAllText(vttPath, "WEBVTT\n\n00:00:00.000 --> 00:00:05.000\nHello world.");
            }

            // Create a <video> element
            Aspose.Html.Dom.Element video = document.CreateElement("video");
            video.SetAttribute("src", "sample.mp4");
            video.SetAttribute("controls", "controls");

            // Create a <track> element referencing the VTT file
            Aspose.Html.Dom.Element track = document.CreateElement("track");
            track.SetAttribute("kind", "captions");
            track.SetAttribute("src", vttPath);
            track.SetAttribute("srclang", "en");
            track.SetAttribute("label", "English");

            // Append the track to the video, and the video to the body
            video.AppendChild(track);
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.Body;
            body.AppendChild(video);

            // Save the modified HTML document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}