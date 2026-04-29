// Add a missing <track> element with kind="captions" and appropriate src attribute to a video element programmatically.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Saving;

namespace AddTrackToVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing HTML document
                HTMLDocument document = new HTMLDocument("input.html");

                // Get all <video> elements in the document
                HTMLCollection videos = document.GetElementsByTagName("video");

                // Iterate through each video element
                foreach (Element video in videos)
                {
                    bool hasCaptionsTrack = false;

                    // Check if a <track> with kind="captions" already exists
                    HTMLCollection tracks = video.GetElementsByTagName("track");
                    foreach (Element track in tracks)
                    {
                        string kind = track.GetAttribute("kind");
                        if (!string.IsNullOrEmpty(kind) && kind.Equals("captions", StringComparison.OrdinalIgnoreCase))
                        {
                            hasCaptionsTrack = true;
                            break;
                        }
                    }

                    // If missing, create and append the <track> element
                    if (!hasCaptionsTrack)
                    {
                        // Create a new <track> element
                        Element track = document.CreateElement("track");
                        // Set required attributes
                        track.SetAttribute("kind", "captions");
                        track.SetAttribute("src", "captions.vtt"); // Adjust the source as needed
                        // Append the track to the video element
                        video.AppendChild(track);
                    }
                }

                // Save the modified document
                document.Save("output.html", new HTMLSaveOptions());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}