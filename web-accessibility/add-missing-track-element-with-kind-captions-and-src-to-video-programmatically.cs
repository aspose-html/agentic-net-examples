// Add a missing <track> element with kind="captions" and appropriate src attribute to a video element programmatically.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a video element lacking a captions track
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><video src='movie.mp4'></video></body></html>";

            // Load HTML from string (use two-argument constructor with a dummy base URI)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all video elements
            Aspose.Html.Collections.HTMLCollection videos = document.GetElementsByTagName("video");

            foreach (Aspose.Html.Dom.Element video in videos)
            {
                // Check if a <track> with kind=\"captions\" already exists
                bool hasCaptionsTrack = false;
                Aspose.Html.Collections.HTMLCollection tracks = video.GetElementsByTagName("track");
                foreach (Aspose.Html.Dom.Element existingTrack in tracks)
                {
                    string kind = existingTrack.GetAttribute("kind");
                    if (!string.IsNullOrEmpty(kind) && kind.Equals("captions", StringComparison.OrdinalIgnoreCase))
                    {
                        hasCaptionsTrack = true;
                        break;
                    }
                }

                // If missing, create and append the track element
                if (!hasCaptionsTrack)
                {
                    Aspose.Html.Dom.Element track = document.CreateElement("track");
                    track.SetAttribute("kind", "captions");
                    track.SetAttribute("src", "captions.vtt");
                    video.AppendChild(track);
                }
            }

            // Prepare output directory and file
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "result.html");

            // Save the modified document
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, saveOptions);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}