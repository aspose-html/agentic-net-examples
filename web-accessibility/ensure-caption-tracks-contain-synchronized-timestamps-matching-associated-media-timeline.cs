// Ensure caption tracks contain synchronized timestamps matching the associated media timeline.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Create sample HTML with a video element
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><video id=\"vid\" controls></video></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the video element
            Aspose.Html.Dom.Element video = document.GetElementById("vid");

            // Create a track element for captions
            Aspose.Html.Dom.Element track = document.CreateElement("track");
            track.SetAttribute("kind", "captions");
            track.SetAttribute("srclang", "en");
            track.SetAttribute("label", "English");
            track.SetAttribute("src", "captions.vtt");

            // Append the track to the video element
            video.AppendChild(track);

            // Save the HTML file
            string htmlPath = Path.Combine(outputDir, "video_with_captions.html");
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(htmlPath, saveOptions);

            // Generate a simple VTT file with synchronized timestamps
            string vttContent = "WEBVTT\n\n" +
                                "00:00.000 --> 00:05.000\n" +
                                "Hello World\n\n" +
                                "00:05.000 --> 00:10.000\n" +
                                "Second caption\n";

            string vttPath = Path.Combine(outputDir, "captions.vtt");
            File.WriteAllText(vttPath, vttContent);

            Console.WriteLine("HTML and caption track files have been created successfully:");
            Console.WriteLine(htmlPath);
            Console.WriteLine(vttPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}